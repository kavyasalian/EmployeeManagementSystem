import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/service/authentication.service';

@Component({
  selector: 'app-topnav',
  templateUrl: './topnav.component.html',
  styleUrls: ['./topnav.component.css']
})
export class TopnavComponent implements OnInit {

  constructor(private authService:AuthenticationService) { }

  ngOnInit(): void {
  }
  logOut(){
  this.authService.logout();
  }
}
