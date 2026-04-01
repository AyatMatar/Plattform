
export interface UserForLogin {
  userName: string;
  password: string;
}

export interface UserLogin {
  id: number;
  userName: string;
  firstName: string;
  lastName: string;
  fullName: string;
  token: string;
  //role:string
}
