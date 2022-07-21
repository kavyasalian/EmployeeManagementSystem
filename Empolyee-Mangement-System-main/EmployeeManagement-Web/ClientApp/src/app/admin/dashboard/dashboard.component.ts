import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin.service';
import { Statistics } from '../Model/common.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  statistics!:Statistics;
  constructor(private adminService:AdminService) { }

  ngOnInit(): void {
    this.adminService.getStatistics().subscribe( data =>{
      this.statistics = data;
      console.log("status report recieved");
      
    });
  }

}
