import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;
export class LoginURLConstants {
  static LOGIN = apiUrl + '/user/Login';
}
export class USERURLConstants {
  static GETALL = apiUrl + '/user/GetAllUser';
  static GET_BY_ID = apiUrl + '/User/GetUserById?Id=';
}
export class EmployeeURLConstants {
  static GET_ALL_EMPLOYEES = apiUrl + '/Employee/GetAllEmployees';
  static DELETE_EMPLOYEES = apiUrl + '/Employee/DeleteEmployee';
}
export class CompanyURLConstant {
  static GET_ALL_COMPANY = apiUrl + '/Company/GetAllCompany';
}