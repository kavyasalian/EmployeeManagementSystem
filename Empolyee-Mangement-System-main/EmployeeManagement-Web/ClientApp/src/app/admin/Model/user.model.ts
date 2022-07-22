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
