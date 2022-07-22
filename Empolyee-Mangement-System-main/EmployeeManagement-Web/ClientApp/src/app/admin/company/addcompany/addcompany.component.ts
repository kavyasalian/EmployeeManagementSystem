import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AdminService } from '../../admin.service';
import { CompanyCreateModel, CompanyViewModel } from '../../Model/company.model';
import { EmployeeCreateModel } from '../../Model/employee.model';


@Component({
  selector: 'app-addcompany',
  templateUrl: './addcompany.component.html',
})
export class AddcompanyComponent implements OnInit {
   addCompany!:FormGroup;
  
 
   constructor(private formBuilder: FormBuilder,private adminService:AdminService, private location:Location) {}

  ngOnInit(): void {
    this.addCompany= this.formBuilder.group({
            companyName: new FormControl(""),
            companyAddress:new FormControl(""),
            companyPhone:new FormControl(""),
          });
          
        }

 createCompany(){
    let comapny= new CompanyCreateModel();
    comapny.companyName=this.addCompany.controls['companyName'].value;
    comapny.companyAddress=this.addCompany.controls['companyAddress'].value;
    comapny.companyPhone=this.addCompany.controls['companyPhone'].value;
    this.adminService.createCompany(comapny).subscribe((data)=>{
      alert("Saved");
      this.location.back();
      
    });
     }
     goBack(){
      this.location.back();
    }
    
  }