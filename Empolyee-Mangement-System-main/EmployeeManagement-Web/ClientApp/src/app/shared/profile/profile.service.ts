import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeURLConstants, USERURLConstants } from '../constants/url-constant';
import { UserViewModel } from './model/user.model';

@Injectable({
  providedIn: 'root',
})
export class ProfileService {
  constructor(private http: HttpClient) {}

  getEmployee(id: number): Observable<UserViewModel> {
    return this.http.get<UserViewModel>(
      USERURLConstants.GET_BY_ID + id 
    );
  }
}
