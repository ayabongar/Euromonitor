import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CatalogService {

  private apiUrl = 'https://localhost:44388/api/catalog';

  constructor(private http: HttpClient) { }

  addBook(book: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/add`, book);
  }

  getAllBooks(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}`);
  }

}
