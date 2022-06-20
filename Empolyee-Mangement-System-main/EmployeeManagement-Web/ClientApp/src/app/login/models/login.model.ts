export class AuthModel{
    userId!: number;
    userName!: string;
    tokenExpiryDate!: string;
    token!: string;
    error: string="";
    userRole: string="";
    payMentInfo:string="";
}
