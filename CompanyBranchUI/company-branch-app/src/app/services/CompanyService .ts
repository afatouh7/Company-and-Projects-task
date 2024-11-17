import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  private apiUrl = 'http://localhost:5029/api/Companies';

  constructor(private http: HttpClient) {}

  getCompanies(pageNumber: number, pageSize: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/get-all-companies/?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  } 
  addCompany(company: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/add-new-company`, company);
  }
}
