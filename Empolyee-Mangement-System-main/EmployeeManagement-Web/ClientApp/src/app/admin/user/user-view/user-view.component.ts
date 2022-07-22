import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserCreateModel } from 'src/app/shared/profile/model/user.model';
import { AdminService } from '../../admin.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-user-view',
  templateUrl: './user-view.component.html',
  styleUrls: ['./user-view.component.css']
})
export class UserViewComponent implements OnInit {
  UserId!: number;
  user!: UserCreateModel;
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
