import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;
export class LoginURLConstants {
  static LOGIN = apiUrl + '/user/Login';
}
export class USERURLConstants {
  static GETALL = apiUrl + '/user/GetAllUser';
  static GET_BY_ID = apiUrl + '/User/GetUserById/';
}
export class EmployeeURLConstants {
  static GET_ALL_EMPLOYEES = apiUrl + '/Employee/GetAllEmployees';
  static DELETE_EMPLOYEES = apiUrl + '/Employee/DeleteEmployeeById/';
  static SEARCH_EMPLOYEE_BY_NAME= apiUrl+'/Employee/SearchByEmployeeName';
  static CREATE_EMPLOYEES = apiUrl + '/Employee/SaveEmployee';
  static UPDATE_EMPLOYEES = apiUrl + '/Employee/UpdateEmployee';
  static GET_EMPLOYEE_BYID = apiUrl + '/Employee/GetEmployeeById/';
}

export class CompanyURLConstants{
  static GET_ALL_COMPANY=apiUrl +'/Company/GetAllCompany';
  static GET_COMPANY_BY_ID=apiUrl +'/Company/GetCompanyById/';
  static UPDATE_COMPANY=apiUrl +'/Company/UpdateCompany';
  static DELETE_COMPANY=apiUrl +'/Company/DeleteCompany';
  static CREATE_COMPANY = apiUrl +'/Company/SaveCompany';
}

export class ProjectURLConstants{
  static GET_ALL_PROJECT=apiUrl +'/Project/GetAllProjects';
  static CREATE_PROJECTS=apiUrl +'/Project/SaveProject';
}