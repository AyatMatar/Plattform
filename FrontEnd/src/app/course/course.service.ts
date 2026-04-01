import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Status } from '../models/status';
import { Course } from './course';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private _httpClient: HttpClient) { }
  url: string = "https://localhost:7088/api/Course";

  addCourse(course: Course): Observable<Status> {
    return this._httpClient.post<Status>(`${this.url}/addCourse`, course);
  }
  updateCourse(course: Course): Observable<Status> {
    return this._httpClient.put<Status>(`${this.url}/updateCourse`, course);
  }
  getCourseById(id: number): Observable<Course> {
    return this._httpClient.get<Course>(`${this.url}/getCourseById/${id}`);
  }

  getAllCourses(): Observable<Course[]> {
    return this._httpClient.get<Course[]>(`${this.url}/getAll`);
  }
  deleteCourse(id: number): Observable<Status> {
    return this._httpClient.delete<Status>(`${this.url}/deleteCourse/${id}`);
  }
  getCoursesByDepartmentId(departmentId: number): Observable<Course[]> {
    return this._httpClient.get<Course[]>(`${this.url}/getCoursesByDepartmentId/${departmentId}`);
  }
}
