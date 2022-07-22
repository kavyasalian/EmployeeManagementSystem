import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserCreateModel, UserViewModel } from 'src/app/shared/profile/model/user.model';
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
