import { ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { OES_ClassDto, OES_ClassService } from '@proxy/class';
import { OES_TestDto, OES_TestService } from '@proxy/test';

@Component({
  selector: 'app-student-test-result',
  templateUrl: './student-test-result.component.html',
  styleUrls: ['./student-test-result.component.scss'],
  providers: [ListService]
})
export class StudentTestResultComponent implements OnInit {
  test = { items: [], totalCount: 0 } as PagedResultDto<OES_TestDto>;
  class = { items: [], totalCount: 0 } as PagedResultDto<OES_ClassDto>;
  form: FormGroup; // add this line

 
  selectedTest = {} as OES_TestDto;
  isModalOpen = false;
  constructor(public readonly list: ListService, private testService: OES_TestService,private classService: OES_ClassService,
    private fb: FormBuilder, private confirmation: ConfirmationService,private _router: Router ) { }

    ngOnInit(): void {
      const testStreamCreator = (query) => this.testService.getResultList(query);
      const classStreamCreator = (query) => this.classService.getList(query);
      this.list.hookToQuery(testStreamCreator).subscribe((response) => {
        this.test = response;
      });
     
      
    }
   
  download(id){
    this.testService.downloadResult(id).subscribe(data => this.downloadFile(data)),//console.log(data),
                 error => console.log('Error downloading the file.'),
                 () => console.info('OK');


  } 
  downloadFile(data: any) {
    const blob = new Blob([data], { type: 'text/docx' });
    const url= window.URL.createObjectURL(blob);

    var downloadURL = window.URL.createObjectURL(data);
    var link = document.createElement('a');
    link.href = url;
    link.download = "StudentResult.docx";
    link.click();
    
  }
    
    
    
  

}
