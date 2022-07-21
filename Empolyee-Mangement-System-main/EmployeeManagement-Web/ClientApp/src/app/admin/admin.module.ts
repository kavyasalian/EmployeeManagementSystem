import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { AdminRoutingModule } from './admin-routing.module';
import { SidebarComponent } from '../shared/sidebar/sidebar.component';
import { SidebarfooterComponent } from '../shared/sidebarfooter/sidebarfooter.component';
import { TopnavComponent } from '../shared/topnav/topnav.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EmployeeComponent } from './employee/employee.component';
import { CompanyComponent } from './company/company.component';
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';
import { EmployeeViewComponent } from './employee-view/employee-view.component';
import { AddemployeeComponent } from './employee/addemployee/addemployee.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EditCompanyComponent } from './company/edit-company/edit-company.component';
import { AddprojectComponent } from './project/addproject/addproject.component';
import { UserComponent } from './user/user.component';
import { AddUserComponent } from './user/add-user/add-user.component';
import { ProjectComponent } from './project/project.component';
import { AddcompanyComponent } from './company/addcompany/addcompany.component';
import { CompanyViewComponent } from './company/company-view/company-view.component';



@NgModule({
  declarations: [
    AdminComponent,
    SidebarComponent,
    SidebarfooterComponent,
    TopnavComponent,
    DashboardComponent,
    EmployeeComponent,
    CompanyComponent,
        EditEmployeeComponent,
        EmployeeViewComponent,
        AddemployeeComponent,
        EditCompanyComponent,
        ProjectComponent,
        AddprojectComponent,
        UserComponent,
        AddUserComponent,
        AddcompanyComponent,
        CompanyViewComponent,
        

        
  ],
  imports: [CommonModule, AdminRoutingModule, ReactiveFormsModule],
})
export class AdminModule {}
