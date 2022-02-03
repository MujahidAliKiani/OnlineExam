import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { OES_TestDto, OES_TestService } from '@proxy/test';
import { OES_Test_ItemDto, OES_Test_ItemService } from '@proxy/test-items';
import { CdTimerComponent } from 'angular-cd-timer';


@Component({
  selector: 'app-student-test',
  templateUrl: './student-test.component.html',
  styleUrls: ['./student-test.component.scss'],
  providers:[ListService]
})
export class StudentTestComponent implements OnInit {


studentTest;
id="";
count=0;
timerValue = 140;
selectedTest = {} as OES_Test_ItemDto;
isModalOpen = false;
form: FormGroup; // add this line

constructor(public readonly list: ListService,private router: Router,private testService: OES_TestService,private testItemService: OES_Test_ItemService,
   private confirmation: ConfirmationService,private fb: FormBuilder,private activatedRoute: ActivatedRoute ) { }

  
  ngOnInit(): void {
    
    this.id = this.activatedRoute.snapshot.paramMap.get("id");

    const request =  this.testService.getStudentTestList(this.id);
    
    request.subscribe((response) => {
      this.studentTest  = response;
      if(this.studentTest.id == "00000000-0000-0000-0000-000000000000")
      {
        this.router.navigateByUrl("test");
      }
    });

}
nextQuestion(){
  const request =  this.testItemService.updateStudentAnswer(this.studentTest.id, this.studentTest.answer);
  request.subscribe((response) => {
    window.location.reload();
  });
}



}
