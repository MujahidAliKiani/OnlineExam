import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OES_StudentService } from '@proxy';
import { OES_ClassDto, OES_ClassService } from '@proxy/class';
import { OES_StudentDto } from '@proxy/student';
import { PermissionService } from '@abp/ng.core';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss'],
  providers: [ListService]
})
export class StudentComponent implements OnInit {
  student = { items: [], totalCount: 0 } as PagedResultDto<OES_StudentDto>;
  class = { items: [], totalCount: 0 } as PagedResultDto<OES_ClassDto>;
  form: FormGroup; // add this line
  selectedStudent = {} as OES_StudentDto;
  isModalOpen = false;
  constructor(public readonly list: ListService, private studentService: OES_StudentService,private classService: OES_ClassService,
    private fb: FormBuilder, private confirmation: ConfirmationService,private permissionService: PermissionService) { }

  ngOnInit(): void {
    const canCreate = this.permissionService.getGrantedPolicy('StudentManagement');
    const studentStreamCreator = (query) => this.studentService.getList(query);
    const classStreamCreator = (query) => this.classService.getList(query);
    this.list.hookToQuery(studentStreamCreator).subscribe((response) => {
      this.student = response;
    });
    this.list.hookToQuery(classStreamCreator).subscribe((response) => {
      this.class = response;
    });
  }
  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.studentService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
  createStudent() {
    this.selectedStudent = {} as OES_StudentDto;
    
    this.buildForm(); // add this line
    this.isModalOpen = true;
  }
  editTest(id: string) {
    this.studentService.get(id).subscribe((class1) => {
      this.selectedStudent = class1;
      this.form = this.fb.group({
        
        email:[class1.email,Validators.required],
        
        registriationNumber:[class1.registriationNumber],
        classId:[class1.classId,Validators.required]
        
      });
     
      this.isModalOpen = true;
    });
  }
  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      
      email:['',Validators.email],
      
      registriationNumber:['',Validators.required],
      classId:['',Validators.required]
      
    });
  }
  save() {
    if (this.form.invalid) {
      return;
    }
    const request = this.selectedStudent.id
      ? this.studentService.update(this.selectedStudent.id, this.form.value)
      : this.studentService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });

}

}
