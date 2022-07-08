import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/service/authentication.service';
import { UserViewModel } from './model/user.model';
import { ProfileService } from './profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  userId!:number;
  employeeDetail!: UserViewModel;
  constructor(private authService:AuthenticationService, private profileService:ProfileService) { }

  ngOnInit(): void {
    this.userId = this.authService.currentUserValue.userId;   
    this.profileService.getEmployee(this.userId).subscribe((data)=>{
      this.employeeDetail = data;
    });
  }

}
