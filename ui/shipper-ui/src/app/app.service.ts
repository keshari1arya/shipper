import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'; 

@Injectable({
  providedIn: 'root'
})
export class AppService {

  private baseUrl = 'https://localhost:7173/api';

  constructor(private http: HttpClient) { }

  getRandomQuote(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/quote/random`);
  }

  getQuotesByAuthor(author: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/quote/author/${author}`);
  }

  getShippers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/shipper`);
  }

  getShipmentsByShipper(shipperId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/shipper/${shipperId}/shipment-details`);
  }
}
