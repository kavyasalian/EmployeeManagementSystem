import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, Form, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
            companyName: new FormControl("",Validators.required),
            companyAddress:new FormControl("",Validators.required),
            companyPhone:new FormControl("",Validators.required),
          });
          
        }

 createCompany(){
  if (this.addCompany.invalid) return;
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
    get f(): { [key: string]: AbstractControl } {
      return this.addCompany.controls;
    }
  }