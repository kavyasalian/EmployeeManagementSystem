import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EmployeeURLConstants } from "../shared/constants/url-constant";
import { EmployeeViewModel } from "./Model/employee.model";

@Injectable({
    providedIn: 'root',
})
export class AdminService{
    constructor(private http:HttpClient){}

    getAllEmployees(){
        return this.http.get<EmployeeViewModel[]>(EmployeeURLConstants.GET_ALL_EMPLOYEES);
      }
}