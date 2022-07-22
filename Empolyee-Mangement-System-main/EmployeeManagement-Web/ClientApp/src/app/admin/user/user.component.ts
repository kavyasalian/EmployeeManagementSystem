import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserCreateModel } from 'src/app/shared/profile/model/user.model';
//import { UserCreateModel } from 'src/app/shared/profile/model/user.model';
import { AdminService } from '../admin.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  userList!: UserCreateModel[];
  constructor(private adminService: AdminService, private router: Router) {}

  ngOnInit(): void {
    this.adminService.getAllUser().subscribe((data) => {
      this.userList = data;
    });
  }
  

  viewUser(id: number) {
    this.router.navigate(['admin/UserView', id]);
   }

  updateUser(id: number) { }

  deleteUser(id: number) { }

  addUser(id: number){
    this.router.navigate(['admin/User/', id]);
  }
}
