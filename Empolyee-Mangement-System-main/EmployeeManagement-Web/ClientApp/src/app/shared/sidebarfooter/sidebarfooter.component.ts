import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/service/authentication.service';

@Component({
  selector: 'app-sidebarfooter',
  templateUrl: './sidebarfooter.component.html',
  styleUrls: ['./sidebarfooter.component.css'],
})
export class SidebarfooterComponent implements OnInit {
  constructor(private authService: AuthenticationService) {}

  ngOnInit(): void {}
  logOut() {
    this.authService.logout();
  }
}
