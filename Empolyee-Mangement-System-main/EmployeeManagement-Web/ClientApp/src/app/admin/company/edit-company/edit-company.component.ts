import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from '../../admin.service';
import { CompanyViewModel } from '../../Model/company.model';

@Component({
  selector: 'app-edit-company',
  templateUrl: './edit-company.component.html',
  styleUrls: ['./edit-company.component.css']
})
export class EditCompanyComponent implements OnInit {
  editCompanyForm!: FormGroup;
  companyId!: number;
  companyDetails!: CompanyViewModel;

  constructor(
    private formBuilder: FormBuilder,
    private location: Location,
    private route: ActivatedRoute,
    private adminService: AdminService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.companyId = params['compayId'];
    });

    this.editCompanyForm = this.formBuilder.group({
      companyId: new FormControl(''),
      companyName: new FormControl(''),
      companyAddress: new FormControl(''),
      companyPhone: new FormControl(''),
    });

    this.adminService.getCompanyById(this.companyId).subscribe(data => {
      this.editCompanyForm.controls['companyId'].setValue(data.companyId);
      this.editCompanyForm.controls['companyName'].setValue(data.companyName);
      this.editCompanyForm.controls['companyAddress'].setValue(data.companyAddress);
      this.editCompanyForm.controls['companyPhone'].setValue(data.companyPhone);
    });
  }
  goBack() {
    this.location.back();
  }
  updateCompany() {
    let updatedCompany: CompanyViewModel = {
      companyId: this.editCompanyForm.controls['companyId'].value,
      companyName: this.editCompanyForm.controls['companyName'].value,
      companyAddress: this.editCompanyForm.controls['companyAddress'].value,
      companyPhone: this.editCompanyForm.controls['companyPhone'].value,
    };
    this.adminService.updateCompany(updatedCompany).subscribe(data => {
      alert("Company Details Updated✌️" + data);
      this.goBack();
    });
  }

}
