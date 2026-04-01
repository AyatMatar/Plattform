import { Data } from "@angular/router";

export class User {
  id!: number;
  firstName!: string;
  lastName!: string;
  email!: string;
  password!: string;
  confirmPassword!: string;
  nationalNumber!: string;
  address!: string;
  phoneNumber!: string;
  dateOfBirth: string | number | Date | null | undefined;
  username!: string;
  gender: string ="";
}
