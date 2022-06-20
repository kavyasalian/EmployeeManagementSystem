import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { AuthenticationService } from '../core/service/authentication.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  submitted: Boolean = false;

  constructor( private formBuilder: FormBuilder,  private authenticationService: AuthenticationService,private router: Router,) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ["", Validators.required],
      password: ["", Validators.required],
    });
    debugger
  }
  get f(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
  }
  login() {

    this.submitted = true;
    if (this.loginForm.invalid)
      return;
      const userName = this.loginForm.value.username;
      const passWord = this.loginForm.value.password;
        this.authenticationService.login(userName, passWord)
      .subscribe(
        (data) => {
          this.router.navigate(["/admin"]);
      
        })
  }

}
