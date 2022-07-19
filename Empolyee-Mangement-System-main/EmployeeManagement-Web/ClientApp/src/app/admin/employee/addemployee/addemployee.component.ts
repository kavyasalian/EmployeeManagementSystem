import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AdminService } from '../../admin.service';
import { CompanyViewModel } from '../../Model/company.model';
import { EmployeeCreateModel } from '../../Model/employee.model';

@Component({
  selector: 'app-addemployee',
  templateUrl: './addemployee.component.html',
  // styleUrls: ['./addemployee.component.css']
})
export class AddemployeeComponent implements OnInit {
  addEmployee!: FormGroup;
  companies!:CompanyViewModel[];
  constructor(private formBuilder: FormBuilder,private adminService:AdminService,private location:Location) {}

  ngOnInit(): void {
    this.addEmployee= this.formBuilder.group({
      firstName: new FormControl(""),
      lastName:new FormControl(""),
      email:new FormControl(""),
      gender:new FormControl(""),
      phoneNo:new FormControl(""),
      companyId:new FormControl(""),
    });
    this.adminService.getAllCompany().subscribe((data) =>{
      this.companies = data;      
    });
  }

  createEmployee(){
    let employee=new EmployeeCreateModel();
    employee.firstName=this.addEmployee.controls['firstName'].value;
    employee.lastName=this.addEmployee.controls['lastName'].value;
    employee.gender=this.addEmployee.controls['gender'].value;
    employee.phone=this.addEmployee.controls['phoneNo'].value;
    employee.email=this.addEmployee.controls['email'].value;
    employee.companyId=this.addEmployee.controls['companyId'].value;
    this.adminService.createEmployee(employee).subscribe((data) =>{
       alert("Saved")    ;
       this.location.back();
    });
  }
  goBack(){
    this.location.back();
  }
}
