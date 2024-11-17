import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PagedResult } from '../models/PagedResult';
import { Branch, CreateBranch } from '../models/branch';
import { HttpClient,HttpParams } from '@angular/common/http'; 

@Injectable({
  providedIn: 'root'
})
export class BranchService {
  private apiUrl = 'http://localhost:5029/api/branches'; // Update with your backend URL

  constructor(private http: HttpClient) {}

  getAllBranches(pageNumber: number = 1, pageSize: number = 10): Observable<PagedResult<Branch>> {
    const params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<PagedResult<Branch>>(this.apiUrl, { params });
  }

  getBranch(id: number): Observable<Branch> {
    return this.http.get<Branch>(`${this.apiUrl}/${id}`);
  }

  createBranch(branch: CreateBranch): Observable<CreateBranch> {
    return this.http.post<CreateBranch>(this.apiUrl, branch);
  }

  updateBranch(id: number, branch: Branch): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, branch);
  }

  deleteBranch(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}