import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeURLConstants } from '../shared/constants/url-constant';
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
  );}
  searchByEmployeeName(name:string){
    EmployeeURLConstants.SEARCH_EMPLOYEE_BY_NAME,{params:{employeeName:name}}
  }
}
