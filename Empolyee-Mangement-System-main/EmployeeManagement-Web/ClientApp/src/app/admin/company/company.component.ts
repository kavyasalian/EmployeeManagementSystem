import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../admin.service';
import { CompanyViewModel } from '../Model/company.model';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {
  companyList!: CompanyViewModel[];
  constructor(private adminService: AdminService, private router: Router) { }


  ngOnInit(): void {
    this.adminService.getAllCompany().subscribe((data) => {
      this.companyList = data;
    });

  }
  deleteCompany(id: number) {
    this.adminService.deleteCompany(id).subscribe((data) => {
      if (data == 200) {
        alert("deleted Company Details");
       this.adminService.getAllCompany().subscribe((data) => {
      this.companyList=data;
        });
      }
      },
      (error)=>{
      alert("Cannot delete company as there is Employee associated with it.");
     
    }
    );
  }
  viewCompany(id: number) {
    this.router.navigate(['admin/CompanyView'])
  }

  editCompany(compayId: number) {
    this.router.navigate(['admin/EditCompany', compayId]);
  }

}