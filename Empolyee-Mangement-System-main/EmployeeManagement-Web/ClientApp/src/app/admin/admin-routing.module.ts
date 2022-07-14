import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EmployeeComponent } from './employee/employee.component';
import { CompanyComponent } from './company/company.component';
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';
import { EmployeeViewComponent } from './employee-view/employee-view.component';
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
  path: 'Company',
  component: CompanyComponent
},
{
  path: 'EditEmployee',
  component: EditEmployeeComponent
},
{
  path: 'EmployeeView',
 component: EmployeeViewComponent

}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
