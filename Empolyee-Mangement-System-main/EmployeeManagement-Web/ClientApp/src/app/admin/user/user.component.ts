import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthModel } from 'src/app/login/models/login.model';
import { AdminService } from '../admin.service';
import { ViewUserModel } from '../Model/user.model';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  userList!: ViewUserModel[];
  currentid!:number;
  constructor(private router: Router, private adminService: AdminService) {}

  ngOnInit(): void {
    this.adminService.getAllUsers().subscribe((data) => {
      this.userList = data;
    });
    const loguser = JSON.parse(localStorage.getItem('currentUser') || '{}');
    this.currentid = loguser.userId;
  }

    viewUser(id: number) {
        this.router.navigate(['admin/UserView', id]);
    }

  updateUser(id: number) {
    
    this.route.navigate(['admin/UpdateUser/', id]);
  }

  deleteUser(id: number) {}

  addUser(id: number) {
    this.route.navigate(['admin/User/', id]);
  }
}
