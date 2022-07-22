import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AdminService } from '../../admin.service';
import { Location } from '@angular/common';
import { RoleViewModel } from '../../Model/role.model';
import { UserCreateModel } from '../../Model/user.model';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  addUser!: FormGroup;
  role!:RoleViewModel[];
  constructor(private formBuilder: FormBuilder,private adminService:AdminService,private location:Location) { }

  ngOnInit(): void {
    this.addUser= this.formBuilder.group({
      firstName: new FormControl(""),
      lastName:new FormControl(""),
      email:new FormControl(""),
      gender:new FormControl(""),
      phoneNo:new FormControl(""),
      companyId:new FormControl(""),
  });
  this.adminService.getAllRole().subscribe((data)=>{
    this.role = data;
  });
}
  createUser(){
    let User=new UserCreateModel();
    User.UserfirstName=this.addUser.controls['firstName'].value;
    User.UserlastName=this.addUser.controls['lastName'].value;
    User.Usergender=this.addUser.controls['gender'].value;
    User.Userphone=this.addUser.controls['phoneNo'].value;
    User.Useremail=this.addUser.controls['email'].value;
    User.UserRoleID=this.addUser.controls['RoleId'].value;
    this.adminService.addUser(User).subscribe((data) =>{
       alert("Saved")    ;
       this.location.back();
    });       
  }
  goBack(){
    this.location.back();
  }
  
}

