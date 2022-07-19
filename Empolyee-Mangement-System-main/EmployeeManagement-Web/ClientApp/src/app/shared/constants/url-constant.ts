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
  static DELETE_EMPLOYEES = apiUrl + '/Employee/DeleteEmployee';
  static SEARCH_EMPLOYEE_BY_NAME= apiUrl+'/Employee/SearchByEmployeeName'
}

export class CompanyURLConstants{
  static GET_ALL_COMPANY=apiUrl +'/Company/GetAllCompany';
  static DELETE_COMPANY=apiUrl +'/Company/DeleteCompany';

}