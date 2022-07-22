import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CompanyCreateModel, CompanyViewModel } from './Model/company.model';
import { CommanURLConstants, CompanyURLConstants, EmployeeURLConstants, ProjectURLConstants, UserURLConstants, USERURLConstants } from '../shared/constants/url-constant';
import { Statistics } from './Model/common.model';
import { EmployeeCreateModel, EmployeeViewModel } from './Model/employee.model';
import { ProjectCreateModel, ProjectViewModel } from './Model/project.model';
import { UserCreateModel } from '../shared/profile/model/user.model';
import { UserModel } from './Model/user.model';

@Injectable({
  providedIn: 'root',
})
export class AdminService {


  constructor(private http: HttpClient) { }

  getAllEmployees(): Observable<EmployeeViewModel[]> {
    return this.http.get<EmployeeViewModel[]>(
      EmployeeURLConstants.GET_ALL_EMPLOYEES
    );
  }
  getAllUser():Observable<UserCreateModel[]>{
    return this.http.get<UserCreateModel[]>(
      USERURLConstants.GETALL
    );
  }
  getAllCompany(): Observable<CompanyViewModel[]> {
    return this.http.get<CompanyViewModel[]>(
      CompanyURLConstants.GET_ALL_COMPANY
    );
  }
  deleteEmployee(id: number) {
    return this.http.delete<any>(
      EmployeeURLConstants.DELETE_EMPLOYEES + id
    );
  }
  deleteCompany(id: number) {
    return this.http.delete<any>(
      CompanyURLConstants.DELETE_COMPANY, { params: { companyId: id } }
    );
  }
  searchByEmployeeName(name: string) {
    return this.http.get<EmployeeViewModel[]>(EmployeeURLConstants.SEARCH_EMPLOYEE_BY_NAME, { params: { employeeName: name } });
  }

  createEmployee(createEmployeeModel: EmployeeCreateModel) {
    return this.http.post(EmployeeURLConstants.CREATE_EMPLOYEES, createEmployeeModel);
  }
  createProject(createProjectModel: ProjectCreateModel) {
    return this.http.post(ProjectURLConstants.CREATE_PROJECTS, createProjectModel)
  }

  updateEmployee(createEmployeeModel: EmployeeCreateModel) {
    return this.http.put(EmployeeURLConstants.UPDATE_EMPLOYEES, createEmployeeModel);
  }

  getAllEmployeeById(id: number): Observable<EmployeeCreateModel> {
    return this.http.get<EmployeeCreateModel>(EmployeeURLConstants.GET_EMPLOYEE_BYID + id);
  }
  getCompanyById(compayId: number) {
    return this.http.get<CompanyCreateModel>(CompanyURLConstants.GET_COMPANY_BY_ID + compayId);
  }
  getUserById(id:number){
    return this.http.get<UserCreateModel>(USERURLConstants.GET_BY_ID +id)
  }
  updateCompany(updateCompanyModel: CompanyViewModel) {
    return this.http.put<CompanyViewModel>(CompanyURLConstants.UPDATE_COMPANY, updateCompanyModel);
  }

  createCompany(createCompanyModel: CompanyCreateModel) {
    return this.http.post(CompanyURLConstants.CREATE_COMPANY, createCompanyModel);
  }
  getAllProject(): Observable<ProjectViewModel[]> {
    return this.http.get<ProjectViewModel[]>(
      ProjectURLConstants.GET_ALL_PROJECT
    );
  }
  createUser(userModel: UserModel) {
    return this.http.post(UserURLConstants.CREATE_USERS, userModel);
   }

  getStatistics() {
    return this.http.get<Statistics>(
      CommanURLConstants.GET_STATISTICS
    );
  }

  deleteProjectById(projectId: number) {
    return this.http.delete<any>(ProjectURLConstants.DELETE_PROJECTS + projectId);
  }
}
