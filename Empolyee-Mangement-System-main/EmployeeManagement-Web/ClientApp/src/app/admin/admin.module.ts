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


@NgModule({
  declarations: [
    AdminComponent,
    SidebarComponent,
    SidebarfooterComponent,
    TopnavComponent,
    DashboardComponent,
    EmployeeComponent,
    CompanyComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
