export class UpdateUserModel {
  userId?: number;
  userFirstName!: string;
  userLastName!: string;
  userEmail!: string;
  userPhone!: string;
  roleId!: number;
  roleName!:string;
}
export class ViewUserModel {
    id!: number;
  firstName!: string;
  lastName!: string;
  email!: string;
  password!: string;
  phone!: string;
  roleId!: number;
    roleName!:string;
}
export class UserModel {
    firstName!: string;
    lastName!: string;
    email!: string;
    password!: string;
    phone!: string;
    roleId!: number;
}
export class UserViewModel{
    UserId!:number;
    UserFirstName!:string;
    UserLastAddress!:string;
    UserGender!:string;
    UserEmail!:string;
    UserPhone!:string;
    RollId!:number;
}
export class UserCreateModel {
    Userid?:number;
     UserfirstName!: string;
     UserlastName!: string;
     Usergender!: string;
     Useremail!: string;
     Userphone!: string;
     UserRoleID!:string;
}
