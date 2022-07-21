import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from '../admin.service';
import { EmployeeCreateModel } from '../Model/employee.model';
import { Location } from '@angular/common';

@Component({
  selector: 'app-employee-view',
  templateUrl: './employee-view.component.html',
  styleUrls: ['./employee-view.component.css'],
})
export class EmployeeViewComponent implements OnInit {
  employeeId!: number;
  employee!: EmployeeCreateModel;
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

    this.adminService.getAllEmployeeById(this.employeeId).subscribe((data) => {
      this.employee = data;
    });
  }
}
