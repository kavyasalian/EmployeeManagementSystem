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
  constructor(private adminService:AdminService,private router:Router) { }

  ngOnInit(): void {
      this.adminService.getAllEmployees().subscribe((data) =>{
      this.employeeList = data;      
    });
    
  }
  deleteEmployee(id:number){
    this.adminService.deleteEmployee(id).subscribe((data)=>{
      if(data==200)
      {
        this.adminService.getAllEmployees().subscribe((data)=>{
          this.employeeList=data;
        });
      }
    })
  }
  viewEmployee(id:number){
    this.router.navigate(['admin/EmployeeView'])
  }
  editEmployee(id:number){
    this.router.navigate(['admin/EditEmployee',id])
  } 
  addEmployee() {
    this.router.navigateByUrl('admin/addEmployee');
  }
}
