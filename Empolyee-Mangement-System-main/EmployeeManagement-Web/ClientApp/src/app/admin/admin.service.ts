import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  CompanyURLConstants,
  EmployeeURLConstants,
  ProjectURLConstants,
  RoleURLConstants,
  UserURLConstants,
} from '../shared/constants/url-constant';
import { CompanyViewModel } from './Model/company.model';
import { EmployeeCreateModel, EmployeeViewModel } from './Model/employee.model';
import { ProjectViewModel } from './Model/project.model';
import { RoleViewModel } from './Model/role.model';
import { UpdateUserModel,ViewUserModel } from './Model/user.model';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  constructor(private http: HttpClient) {}

  getAllEmployees(): Observable<EmployeeViewModel[]> {
    return this.http.get<EmployeeViewModel[]>(
      EmployeeURLConstants.GET_ALL_EMPLOYEES
    );
  }
  getAllCompany(): Observable<CompanyViewModel[]> {
    return this.http.get<CompanyViewModel[]>(
      CompanyURLConstants.GET_ALL_COMPANY
    );
  }
  deleteEmployee(id: number) {
    return this.http.delete<any>(EmployeeURLConstants.DELETE_EMPLOYEES + id);
  }
  deleteCompany(id: number) {
    return this.http.delete<any>(CompanyURLConstants.DELETE_COMPANY, {
      params: { companyId: id },
    });
  }
  searchByEmployeeName(name: string) {
    EmployeeURLConstants.SEARCH_EMPLOYEE_BY_NAME,
      { params: { employeeName: name } };
  }

  createEmployee(createEmployeeModel: EmployeeCreateModel) {
    return this.http.post(
      EmployeeURLConstants.CREATE_EMPLOYEES,
      createEmployeeModel
    );
  }

  updateEmployee(createEmployeeModel: EmployeeCreateModel) {
    return this.http.put(
      EmployeeURLConstants.UPDATE_EMPLOYEES,
      createEmployeeModel
    );
  }

  getAllEmployeeById(id: number): Observable<EmployeeCreateModel> {
    return this.http.get<EmployeeCreateModel>(
      EmployeeURLConstants.GET_EMPLOYEE_BYID + id
    );
  }
  getCompanyById(compayId: number) {
    return this.http.get<CompanyViewModel>(
      CompanyURLConstants.GET_COMPANY_BY_ID + compayId
    );
  }
  updateCompany(updateCompanyModel: CompanyViewModel) {
    return this.http.put<CompanyViewModel>(
      CompanyURLConstants.UPDATE_COMPANY,
      updateCompanyModel
    );
  }
  getAllProject(): Observable<ProjectViewModel[]> {
    return this.http.get<ProjectViewModel[]>(
      ProjectURLConstants.GET_ALL_PROJECT
    );
  }
  updateUser(updateUserModel: UpdateUserModel) {
    return this.http.put<UpdateUserModel>(
      UserURLConstants.UPDATE_USER,
      updateUserModel
    );
  }
  getAllRoles(): Observable<RoleViewModel[]> {
    return this.http.get<RoleViewModel[]>(
      RoleURLConstants.GET_ALL_ROLE
    );
  }
  getAllUsers(): Observable<ViewUserModel[]> {
    return this.http.get<ViewUserModel[]>(
      UserURLConstants.GET_ALL_USER
    );
  }
  getAllUserById(id: number): Observable<ViewUserModel> {
    return this.http.get<ViewUserModel>(
      UserURLConstants.GET_USER_BYID + id
    );
  }
}
