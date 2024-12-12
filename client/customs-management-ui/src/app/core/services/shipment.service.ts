import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Shipment } from '../../features/shipments/models/shipment.model';

@Injectable({
  providedIn: 'root',
})
export class ShipmentService {
  private baseUrl = 'http://localhost:5025/api/Shipment';


  constructor(private http: HttpClient) {}

  // Create a new shipment
  createShipment(shipment: Shipment): Observable<Shipment> {
    return this.http.post<Shipment>(`${this.baseUrl}/create`, shipment);
  }

  // Update shipment status
  updateShipmentStatus(id: number, status: string): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/update-status`, { id, status });
  }

  // Get a specific shipment by ID
  getShipmentById(id: number): Observable<Shipment> {
    return this.http.get<Shipment>(`${this.baseUrl}/get-shipment?id=${id}`);
  }

  // Get all shipments
  getShipments(status?: string, delayedDayCount?: number): Observable<Shipment[]> {
    let url = `${this.baseUrl}/get-shipments`;

    if (status || delayedDayCount) {
      const params = [];
      if (status) params.push(`status=${status}`);
      if (delayedDayCount) params.push(`delayedDayCount=${delayedDayCount}`);
      url += '?' + params.join('&');
    }

    return this.http.get<Shipment[]>(url);
  }

  // Delete a shipment
  deleteShipment(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/delete`, {
      body: { id },
    });
  }
}
