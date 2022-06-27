import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  {
    path: '',
    component: LoginComponent
},
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then(m => m.LoginModule)
},
{
  path: 'admin',
  component: AdminComponent,
  children: [
    {
      path: '',
      loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
    }
  ]
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
