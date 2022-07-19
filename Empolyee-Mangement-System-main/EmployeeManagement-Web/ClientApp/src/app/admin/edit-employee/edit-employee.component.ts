import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminService } from '../admin.service';
import { CompanyViewModel } from '../Model/company.model';
import { EmployeeCreateModel } from '../Model/employee.model';
import { Location } from '@angular/common';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css'],
})
export class EditEmployeeComponent implements OnInit {
  editEmployee!: FormGroup;
  companies!: CompanyViewModel[];
  employeeId!: number;
  constructor(
    private formBuilder: FormBuilder,
    private adminService: AdminService,
    private location: Location,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.employeeId = params['id'];
    });
    this.editEmployee = this.formBuilder.group({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl(''),
      gender: new FormControl(''),
      phoneNo: new FormControl(''),
      companyId: new FormControl(''),
    });
    this.adminService.getAllCompany().subscribe((data) => {
      this.companies = data;
    });
    this.adminService.getAllEmployeeById(this.employeeId).subscribe((data) => {
      this.editEmployee.controls['firstName'].setValue(data.firstName);
      this.editEmployee.controls['lastName'].setValue(data.lastName);
      this.editEmployee.controls['email'].setValue(data.email);
      this.editEmployee.controls['gender'].setValue(data.gender);
      this.editEmployee.controls['phoneNo'].setValue(data.phone);
      this.editEmployee.controls['companyId'].setValue(data.companyId);
    });
  }

  updateEmployee() {
    let employee = new EmployeeCreateModel();
    employee.id=this.employeeId;
    employee.firstName = this.editEmployee.controls['firstName'].value;
    employee.lastName = this.editEmployee.controls['lastName'].value;
    employee.gender = this.editEmployee.controls['gender'].value;
    employee.phone = this.editEmployee.controls['phoneNo'].value;
    employee.email = this.editEmployee.controls['email'].value;
    employee.companyId = this.editEmployee.controls['companyId'].value;
    this.adminService.updateEmployee(employee).subscribe((data) => {
      alert('Updated');
      this.location.back();
    });
  }
  goBack() {
    this.location.back();
  }
}
