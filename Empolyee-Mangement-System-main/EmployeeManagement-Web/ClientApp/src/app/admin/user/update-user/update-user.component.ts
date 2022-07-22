
import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from '../../admin.service';
import { RoleViewModel } from '../../Model/role.model';
import { UpdateUserModel } from '../../Model/user.model';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {
  updateUser!: FormGroup;
  roles!: RoleViewModel[];
  userId!: number;
  constructor(private formBuilder: FormBuilder,
    private adminService: AdminService,
    private location: Location,
    private route: ActivatedRoute) {}

    ngOnInit(): void {
      this.route.params.subscribe((params) => {
        this.userId = params['userId'];
      });
  this.updateUser = this.formBuilder.group({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    phoneNo: new FormControl(''),
    roleId: new FormControl(''),
  });
  this.adminService.getAllRoles().subscribe((data) => {
    this.roles = data;
  });
  this.adminService.getAllUserById(this.userId).subscribe((data) => {
    this.updateUser.controls['firstName'].setValue(data.firstName);
    this.updateUser.controls['lastName'].setValue(data.lastName);
    this.updateUser.controls['email'].setValue(data.email);
    this.updateUser.controls['phoneNo'].setValue(data.phone);
   this.updateUser.controls['roleId'].setValue(data.roleId);
  });
}
editUser() {
  let user = new UpdateUserModel();
  user.userId=this.userId;
  user.userFirstName = this.updateUser.controls['firstName'].value;
  user.userLastName = this.updateUser.controls['lastName'].value;
  user.userPhone = this.updateUser.controls['phoneNo'].value;
  user.userEmail = this.updateUser.controls['email'].value;
  user.roleId = this.updateUser.controls['roleId'].value;
  this.adminService.updateUser(user).subscribe((data) => {
    alert('Updated');
    this.location.back();
  });
}
goBack() {
  this.location.back();
}
}
