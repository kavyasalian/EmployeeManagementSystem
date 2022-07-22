import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { AdminService } from '../admin/admin.service';
import { UserModel } from '../admin/Model/user.model';
import { AuthenticationService } from '../core/service/authentication.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  signinForm!: FormGroup;
  submitted: Boolean = false;

  constructor(
    private adminService: AdminService,
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
    this.signinForm = this.formBuilder.group({
      firstName: new FormControl(""),
      lastName: new FormControl(""),
      email: new FormControl(""),
      password: new FormControl(""),
      phone: new FormControl(""),
    });
  }
  get f(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
  }
  login() {
    this.submitted = true;
    if (this.loginForm.invalid) return;
    const userName = this.loginForm.value.username;
    const passWord = this.loginForm.value.password;
    this.authenticationService.login(userName, passWord).subscribe((data) => {
      this.router.navigate(['/admin']);
    });
  }

  createUser() {
    if (this.signinForm.invalid) {
      alert('Enter the Details');
    } 
    else {
      let signinDetails = new UserModel();
      signinDetails.firstName = this.signinForm.controls['firstName'].value;
      signinDetails.lastName = this.signinForm.controls['lastName'].value;
      signinDetails.email = this.signinForm.controls['email'].value;
      signinDetails.password = this.signinForm.controls['password'].value;
      signinDetails.phone = this.signinForm.controls['phone'].value;
      signinDetails.roleId=1;
      console.log(signinDetails);
      this.adminService.createUser(signinDetails).subscribe((data) => {
        alert('Successfully Signed In');
      this.router.navigate(['/login']);
      });
    }
  }
}
