import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin.service';
import { EmployeeViewModel } from '../Model/employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employeeList!:EmployeeViewModel[];
  constructor(private adminService:AdminService) { }

  ngOnInit(): void {
      this.adminService.getAllEmployees().subscribe((data) =>{
      this.employeeList = data;      
    });
    this.adminService.deleteEmployees().
  }
}
