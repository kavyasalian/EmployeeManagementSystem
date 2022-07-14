import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EmployeeComponent } from './employee/employee.component';
import { CompanyComponent } from './company/company.component';
import { AddcompanyComponent } from './company/addcompany/addcompany.component';

const routes: Routes = [
 
{
  path: '',
  component: DashboardComponent
},
{
  path: 'Empolyee',
  component: EmployeeComponent
},
{
  path: 'Empolyee/Add/:id',
  component: AddemployeeComponent
},
{
  path: 'Company',
  component: CompanyComponent
},
{
  path: 'Company/Add/:id',
  component : AddcompanyComponent
  
 },
 {
  path: 'EditEmployee',
  component: EditEmployeeComponent
},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
