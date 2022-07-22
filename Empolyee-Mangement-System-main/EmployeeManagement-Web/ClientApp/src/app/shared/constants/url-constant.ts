import { ProjectCreateModel } from 'src/app/admin/Model/project.model';
import { environment } from '../../../environments/environment';

const apiUrl = environment.apiUrl;
export class LoginURLConstants {
  static LOGIN = apiUrl + '/user/Login';
}
export class USERURLConstants {
  static GETALL = apiUrl + '/User/GetAllUser';
  static GET_BY_ID = apiUrl + '/User/GetUserById/';
  static SEARCH_USER_BY_NAME = apiUrl +'/User/SearchByUserName';
  static CREATE_USER =apiUrl + '/User/AddUser';
}
export class RoleURLConstants{
  static GET_ALL_ROLE=apiUrl +'/Role/GetAllRoles/';
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
    static CREATE_PROJECTS = apiUrl + '/Project/SaveProject';
    static DELETE_PROJECTS = apiUrl + '/Project/DeleteProjectById/';
}

export class UserURLConstants{
  static CREATE_USERS = apiUrl + '/User/AddUser';
}
  


export class CommanURLConstants{
  static GET_STATISTICS=apiUrl +'/Common/GetStatistics';
}