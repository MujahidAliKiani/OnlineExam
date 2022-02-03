import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OES_TestDto, OES_TestService } from '@proxy/test';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { OES_ClassDto, OES_ClassService } from '@proxy/class';
import { Router } from '@angular/router';
@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
 
})
export class TestComponent implements OnInit {
  test = { items: [], totalCount: 0 } as PagedResultDto<OES_TestDto>;
  class = { items: [], totalCount: 0 } as PagedResultDto<OES_ClassDto>;
  form: FormGroup; // add this line

 
  selectedTest = {} as OES_TestDto;
  isModalOpen = false;
  constructor(public readonly list: ListService, private testService: OES_TestService,private classService: OES_ClassService,
    private fb: FormBuilder, private confirmation: ConfirmationService,private _router: Router ) { }

  ngOnInit(): void {
    const testStreamCreator = (query) => this.testService.getList(query);
    const classStreamCreator = (query) => this.classService.getList(query);
    this.list.hookToQuery(testStreamCreator).subscribe((response) => {
      this.test = response;
    });
    this.list.hookToQuery(classStreamCreator).subscribe((response) => {
      this.class = response;
    });
    
  }
  viewQuestions(id:string)
  {
    var url="test_Item?id="+id;
    this._router.navigateByUrl(url);

  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.testService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
  createTest() {
    this.selectedTest = {} as OES_TestDto;
    
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }
  editTest(id: string) {
    this.testService.get(id).subscribe((class1) => {
      this.selectedTest = class1;
      this.form = this.fb.group({
        testName: [class1.testName, Validators.required],
        date:[class1.date,Validators.required],
        duration:[class1.duration,Validators.required],
        max_Question:[class1.max_Question,Validators.required],
        classId:[class1.classId,Validators.required]
        
      });
     
      this.isModalOpen = true;
    });
  }
  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      testName: ['', Validators.required],
      date:[null,Validators.required],
      duration:[null,Validators.required],
      max_Question:[null,Validators.required],
      classId:[null,Validators.required]
      
    });
  }
  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedTest.id
      ? this.testService.update(this.selectedTest.id, this.form.value)
      : this.testService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });

}
}
