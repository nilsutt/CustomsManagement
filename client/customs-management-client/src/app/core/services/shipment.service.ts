import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Shipment } from '../../features/shipments/models/shipment.model';
import {ShipmentCreate} from '../../features/shipments/models/shipment-create.model';
import {ShipmentUpdate} from '../../features/shipments/models/shipment-update.model';

@Injectable({
  providedIn: 'root',
})
export class ShipmentService {
  private baseUrl = 'http://localhost:5025/api/Shipment';

  constructor(private http: HttpClient) {}

  createShipment(shipment: ShipmentCreate): Observable<Shipment> {
    return this.http.post<Shipment>(`${this.baseUrl}/create`, shipment);
  }

  updateShipmentStatus(id: number, status: string): Observable<void> {
    return this.http.put<void>(`${this.baseUrl}/update-status`, { id, status });
  }

  updateShipment(shipment: ShipmentUpdate): Observable<any> {
    return this.http.put(`${this.baseUrl}/update`, shipment);
  }

  getShipmentById(id: number): Observable<Shipment> {
    return this.http.get<Shipment>(`${this.baseUrl}/get-shipment?id=${id}`);
  }

  getShipments(status?: string, delayedDayCount?: number): Observable<Shipment[]> {
    let url = `${this.baseUrl}/get-shipments`;

    if (status || delayedDayCount) {
      const params: string[] = [];
      if (status) params.push(`status=${status}`);
      if (delayedDayCount) params.push(`delayedDayCount=${delayedDayCount}`);
      url += '?' + params.join('&');
    }

    return this.http.get<Shipment[]>(url);
  }

  deleteShipment(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/delete`, {
      body: { id },
    });
  }
}
