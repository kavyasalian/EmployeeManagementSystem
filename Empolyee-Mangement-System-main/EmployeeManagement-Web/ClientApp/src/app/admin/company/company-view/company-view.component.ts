import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { AdminService } from '../../admin.service';
import { CompanyCreateModel, CompanyViewModel } from '../../Model/company.model';

@Component({
  selector: 'app-company-view',
  templateUrl: './company-view.component.html',
  styleUrls: ['./company-view.component.css']
})
export class CompanyViewComponent implements OnInit {
  companyId!: number;
  company!:CompanyCreateModel;
  constructor(private adminService: AdminService,private route: ActivatedRoute,private location:Location) {}


  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.companyId = params['id'];
    });
    this.adminService.getCompanyById(this.companyId).subscribe((data) => {
      this.company = data;
    });
  }
  goBack() {
    this.location.back();
  }
}
