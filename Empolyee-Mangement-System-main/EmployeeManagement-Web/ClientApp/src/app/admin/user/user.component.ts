import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private route:Router) { }

  ngOnInit(): void {
  }

  viewUser(id: number) { }

  updateUser(id: number) { }

  deleteUser(id: number) { }

  addUser(id: number){
    this.route.navigate(['admin/User/', id]);
  }
}
