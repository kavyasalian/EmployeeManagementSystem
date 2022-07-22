import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from '../../admin.service';
import { Location } from '@angular/common';
import { AddUserModel } from 'src/app/shared/profile/model/user.model';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.css']
})
export class UserViewComponent implements OnInit {
  UserId!: number;
  user!: AddUserModel;
  constructor(
    private adminService: AdminService,
    private location: Location,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.UserId = params['id'];
    });
    this.adminService.getUserById(this.UserId).subscribe((data) => {
      this.user = data;
    });
  }
  goBack(){
    this.location.back();

}
}
