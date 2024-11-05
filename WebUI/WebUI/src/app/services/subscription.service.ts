import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SubscriptionService {
  private apiUrl = 'https://localhost:44388/api/subscription';

  constructor(private http: HttpClient) { }

  subscribe(userId: number, bookId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/subscribe`, { userId, bookId });
  }

  unsubscribe(userId: number, bookId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/unsubscribe`, { userId, bookId });
  }

  getUserSubscriptions(userId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${userId}`);
  }
}
