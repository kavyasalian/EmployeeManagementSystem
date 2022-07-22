import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AddUserModel, UserViewModel } from 'src/app/shared/profile/model/user.model';
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
    
    this.router.navigate(['admin/UpdateUser/', id]);
  }

  deleteUser(id: number) {}

  addUser(id: number) {
    this.router.navigate(['admin/User/', id]);
  }
  onSearch(e: any, name: string) {
    if( name ==''){
      this.adminService. getAllUser().subscribe((data) => {
        this.userList = data;
      });
      return;
    }
    
    if( e.keyCode == 13 || e.type == 'click'){
      this.adminService.searchByUserName(name).subscribe(data => { 
        this.userList = data;
        console.log(data);
      });
    }
  }

  }
