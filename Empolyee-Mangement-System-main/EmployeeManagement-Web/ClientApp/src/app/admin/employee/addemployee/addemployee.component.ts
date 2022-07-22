import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
      firstName: new FormControl("",Validators.required),
      lastName:new FormControl("",Validators.required),
      email:new FormControl("",Validators.required),
      gender:new FormControl("",Validators.required),
      phoneNo:new FormControl("",Validators.required),
      companyId:new FormControl("",Validators.required),
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
    
    if(this.addEmployee.invalid){
      alert("All fields are required!");
      return;
    }
    else{
      this.adminService.createEmployee(employee).subscribe((data) =>{
        alert("Saved")    ;
        this.location.back();
     },(error)=>{
       alert("Please Try Again!");
     });
    }
    
  }
  goBack(){
    this.location.back();
  }
}
