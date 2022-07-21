import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommanURLConstants, CompanyURLConstants, EmployeeURLConstants, ProjectURLConstants } from '../shared/constants/url-constant';
import { Statistics } from './Model/common.model';
import { CompanyViewModel } from './Model/company.model';
import { EmployeeCreateModel, EmployeeViewModel } from './Model/employee.model';
import { ProjectViewModel } from './Model/project.model';

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

  updateEmployee(createEmployeeModel: EmployeeCreateModel) {
    return this.http.put(EmployeeURLConstants.UPDATE_EMPLOYEES, createEmployeeModel);
  }

  getAllEmployeeById(id: number): Observable<EmployeeCreateModel> {
    return this.http.get<EmployeeCreateModel>(
      EmployeeURLConstants.GET_EMPLOYEE_BYID + id
    );
  }
  getCompanyById(compayId: number) {
    return this.http.get<CompanyViewModel>(CompanyURLConstants.GET_COMPANY_BY_ID + compayId);
  }
  updateCompany(updateCompanyModel: CompanyViewModel) {
    return this.http.put<CompanyViewModel>(CompanyURLConstants.UPDATE_COMPANY, updateCompanyModel);
  }
  getAllProject(): Observable<ProjectViewModel[]> {
    return this.http.get<ProjectViewModel[]>(
      ProjectURLConstants.GET_ALL_PROJECT
    );
  }
  getStatistics() {
    return this.http.get<Statistics>(
      CommanURLConstants.GET_STATISTICS
    );
  }
}
