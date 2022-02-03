import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { OES_TestDto, OES_TestService } from '@proxy/test';
import { OES_Test_ItemDto, OES_Test_ItemService } from '@proxy/test-items';

@Component({
  selector: 'app-test-item',
  templateUrl: './test-item.component.html',
  styleUrls: ['./test-item.component.scss'],
  providers: [ListService]
})
export class TestItemComponent implements OnInit {

  testItem = { items: [], totalCount: 0 } as PagedResultDto<OES_Test_ItemDto>;
  test = { items: [], totalCount: 0 } as PagedResultDto<OES_TestDto>;
  form: FormGroup; // add this line

  id = "";
  selectedClass = {} as OES_Test_ItemDto;
  isModalOpen = false;


  constructor(public readonly list: ListService, private testItemService: OES_Test_ItemService,private testService: OES_TestService,
    private fb: FormBuilder, private confirmation: ConfirmationService,private activatedRoute: ActivatedRoute, ) { }

  ngOnInit(): void {

    this.id = this.activatedRoute.snapshot.paramMap.get("id");
    
    const testItemStreamCreator = (id) => this.testItemService.getSelectedList(this.id);
    
    const testStreamCreator = (query) => this.testService.getList(query);

    this.list.hookToQuery(testItemStreamCreator).subscribe((response) => {

      this.testItem = response;
      
    });

    this.list.hookToQuery(testStreamCreator).subscribe((response) => {
      this.test = response;
      
    });
  

  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.testItemService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
  createClass() {
    this.selectedClass = {} as OES_Test_ItemDto;
    
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }
  editClass(id: string) {
    this.testItemService.get(id).subscribe((testItem) => {
      this.selectedClass = testItem;
      this.form = this.fb.group({
        testId: [testItem.testId, Validators.required],
      question:[testItem.question,Validators.required],
      answer:[''],
      duration:[testItem.duration,Validators.required]
       
      });
      this.buildForm();
      this.isModalOpen = true;
    });
  }
  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      testId: [this.id, Validators.required],
    question:['',Validators.required],
    answer:[''],
    duration:['',Validators.required]
     
    });
  }
  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedClass.id
      ? this.testItemService.update(this.selectedClass.id, this.form.value)
      : this.testItemService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });
}

}
