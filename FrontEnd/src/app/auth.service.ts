import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { AlertService } from './alert.service';
import { UserForLogin, UserLogin } from './models/auth';
import { Payload } from './models/payload';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _httpClient: HttpClient, private alert: AlertService, private router: Router) {

    this.userPayload = this.decodedToken();
    console.log("this is my  userPayload")
    console.log(this.userPayload)
  }
  url: string = "https://localhost:7088/api/auth";
  userPayload: Payload;
  //login
  authUser(user: UserForLogin): Observable<UserLogin> {
    return this._httpClient.post <UserLogin>(`${this.url}/login`, user);
  }
  logOut() {
    localStorage.clear();
    this.alert.success("Login Successful")
    this.router.navigateByUrl('user/login');
  }
  storeToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue);
  }
  getToken() {
    return localStorage.getItem('token');
  }
  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
  storeFullName(fullName: string) {
    localStorage.setItem('fullName', fullName);
  }
  getFullName() {
    return localStorage.getItem('fullName');
  }
  decodedToken() {
    const jwtHelper = new JwtHelperService();
    const token = this.getToken();
    if (token)
      return jwtHelper.decodeToken(token);
  }
}
