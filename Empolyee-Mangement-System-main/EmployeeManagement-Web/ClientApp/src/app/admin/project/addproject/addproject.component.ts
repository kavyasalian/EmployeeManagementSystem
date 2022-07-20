import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AdminService } from '../../admin.service';
import { ProjectCreateModel, ProjectViewModel } from '../../Model/project.model';
import { Location } from '@angular/common';

@Component({
  selector: 'app-addproject',
  templateUrl: './addproject.component.html',
  styleUrls: ['./addproject.component.css']
})
export class AddprojectComponent implements OnInit {
  addProject!: FormGroup;
  projects!:ProjectViewModel[];

  constructor(private formBuilder: FormBuilder,private adminService:AdminService,private location:Location) {}

  ngOnInit(): void {
    this.addProject= this.formBuilder.group({
      projectName: new FormControl(""),
      projectDesc:new FormControl(""),
      startDate:new FormControl(""),
      endDate:new FormControl(""),
     
  });
  this.adminService.getAllProject().subscribe((data) =>{
    this.projects= data;   

});
}
createProject(){
  let project=new ProjectCreateModel();
  project.projectName=this.addProject.controls['projectName'].value;
  project.projectDesc=this.addProject.controls['projectDesc'].value;
  project.startDate=this.addProject.controls['startDate'].value;
  project.endDate=this.addProject.controls['endDate'].value;
  
  this.adminService.createProject(project).subscribe((data) =>{
     alert("Saved")    ;
     this.location.back();
  });
}
goBack(){
  this.location.back();
}
}
