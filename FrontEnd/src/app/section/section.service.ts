import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Status } from '../models/status';
import { SectionData, SectionForAddUodate } from '../models/section'

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  constructor(private _httpClient: HttpClient) { }
  url: string = "https://localhost:7088/api/Section"
  addSection(section: SectionForAddUodate): Observable<Status> {
    return this._httpClient.post<Status>(`${this.url}/add`, section);
  }
  updateSection(section: SectionForAddUodate): Observable<Status> {
    return this._httpClient.put<Status>(`${this.url}/update`, section);
  }
  getAllSection(): Observable<SectionData[]> {
    return this._httpClient.get<SectionData[]>(`${this.url}/getAll`);
  }
  getSectionById(id: number): Observable<SectionData> {
    return this._httpClient.get<SectionData>(`${this.url}/getById/${id}`);
  }
  deleteSection(id: number): Observable<Status> {
    return this._httpClient.delete<Status>(`${this.url}/deleteById/${id}`);
  }
  getSectionByCourseId(courseId: number): Observable<SectionData[]> {
    return this._httpClient.get<SectionData[]>(`${this.url}/getSectionByCourseId/${courseId}`);;
  }
}
