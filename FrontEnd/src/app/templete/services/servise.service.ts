import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Status } from '../../models/status';
import { Department, DepartmentLookupDto } from './department';

@Injectable({
  providedIn: 'root'
})
export class ServiseService {
  url: string = "https://localhost:7088/api/Department";
  constructor(private _httpClient: HttpClient) { }
  getAlll(): Observable<Department[]> {
    return this._httpClient.get<Department[]>(`${this.url}/getAll`);
  }
  getAllDepartmentLookup(): Observable<DepartmentLookupDto[]> {
    return this._httpClient.get<DepartmentLookupDto[]>(`${this.url}/getAllDepartmentLookup`);
  }
  
  getById(id: number): Observable<Department> {
    return this._httpClient.get<Department>(`${this.url}/getById/${id}`);
  }

  addUpdate(department: Department): Observable<Status> {
    return this._httpClient.post<Status>(`${this.url}/AddUpdate`, department);
  }

  delete(id: number): Observable<Status> {
    return this._httpClient.delete<Status>(`${this.url}/delete/${id}`);
  }
}
