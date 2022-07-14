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
//   deleteEmployee(id:number){
//     console.log("Delete : " + id);
    
//   }
}
