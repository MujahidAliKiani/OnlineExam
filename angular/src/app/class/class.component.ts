import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { OES_ClassService, OES_ClassDto } from '@proxy/class';

@Component({
  selector: 'app-class',
  templateUrl: './class.component.html',
  styleUrls: ['./class.component.scss'],
  providers: [ListService],

})
export class ClassComponent implements OnInit {
  class = { items: [], totalCount: 0 } as PagedResultDto<OES_ClassDto>;
  form: FormGroup; // add this line

 
  selectedClass = {} as OES_ClassDto;
  isModalOpen = false;
  Name:string="";
  constructor(public readonly list: ListService, private classService: OES_ClassService,
    private fb: FormBuilder, private confirmation: ConfirmationService ) { }

  ngOnInit(): void {
    const bookStreamCreator = (query) => this.classService.getList(query);

    this.list.hookToQuery(bookStreamCreator).subscribe((response) => {
      this.class = response;
    });
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.classService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
  createClass() {
    this.selectedClass = {} as OES_ClassDto;
    this.Name="";
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }
  editClass(id: string) {
    this.classService.get(id).subscribe((class1) => {
      this.selectedClass = class1;
      this.form = this.fb.group({
        name: [class1.name, Validators.required]
       
      });
     
      this.isModalOpen = true;
    });
  }
  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      name: ['', Validators.required]
     
    });
  }
  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedClass.id
      ? this.classService.update(this.selectedClass.id, this.form.value)
      : this.classService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
}
}
