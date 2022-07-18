import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry } from 'rxjs';
import { CompanyURLConstant, EmployeeURLConstants } from '../shared/constants/url-constant';
import { CompanyViewModel } from './Model/company.model';
import { EmployeeViewModel } from './Model/employee.model';

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
  deleteEmployee(id: number) {
   return this.http.delete<any>(
    EmployeeURLConstants.DELETE_EMPLOYEES , {params:{employeeId:id}}
  );
}
  getAllCompany(): Observable<CompanyViewModel[]> {
   return this.http.get<CompanyViewModel[]>(
    CompanyURLConstant.GET_ALL_COMPANY
   );
  }
}
