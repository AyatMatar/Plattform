import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Status } from '../models/status';
import { TeacherDto } from '../models/teacher';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private _httpClient: HttpClient) { }
  url: string = "https://localhost:7088/api/User";


  addUpdateUser(user: User): Observable<Status> {
    return this._httpClient.post<Status>(`${this.url}/AddUpdateUser`, user);

  }

  getAllUser(): Observable<User[]> {
    return this._httpClient.get<User[]>(`${this.url}/getAllUser`);
   // return this._httpClient.get<User[]>(this.url + "/getAllUser");
  }

  deleteUser(id: number): Observable<Status> {
    return this._httpClient.delete<Status>(`${this.url}/deleteUser/${id}`);
  }

  getUserById(id: number): Observable<User> {
    return this._httpClient.get<User>(`${this.url}/getUserById/${id}`);
  }
  getTeam(): Observable<TeacherDto[]> {
    return this._httpClient.get<TeacherDto[]>(`${this.url}/getTeam`);
  }
  //addUser(user: User) {
  //  console.log("Service")
  //  console.log(user)
  //  localStorage.setItem('login-user', JSON.stringify(user));
  //  localStorage.setItem('login', JSON.stringify(user));
  //  localStorage.setItem('user', JSON.stringify(user));
  //  /*  localStorage.removeItem('user')*/
  //  /*    localStorage.clear();*/

  //  let data = localStorage.getItem('login');

  //  console.log("data")
  //  console.log(data)
  //  user = JSON.parse(data || '{}');
  //  console.log("user")
  //  console.log(user)
    
  //}
}
