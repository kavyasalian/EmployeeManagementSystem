import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;
export class LoginURLConstants {
  static LOGIN = apiUrl + '/user/Login';
}
export class USERURLConstants {
  static GETALL = apiUrl + '/user/GetAllUser';
}
export class EmployeeURLConstants {
  static GET_ALL_EMPLOYEES = apiUrl + '/Employee/GetAllEmployees';
}
