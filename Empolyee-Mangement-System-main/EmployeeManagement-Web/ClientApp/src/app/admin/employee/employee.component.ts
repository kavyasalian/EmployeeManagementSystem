import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../admin.service';
import { EmployeeViewModel } from '../Model/employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employeeList!:EmployeeViewModel[];
  constructor(private adminService:AdminService, private route:Router) { }

  ngOnInit(): void {
      this.adminService.getAllEmployees().subscribe((data) =>{
      this.employeeList = data;      
    });
  }
  deleteEmployee(id:number){
    console.log("Delete id: " + id);
    this.route.navigateByUrl('/Company');
  }
}
