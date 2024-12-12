import { Component, OnInit } from '@angular/core';
import { ShipmentService } from '../../../../core/services/shipment.service';
import { Shipment } from '../../models/shipment.model';

@Component({
  selector: 'app-shipment-list',
  templateUrl: './shipment-list.component.html',
  styleUrls: ['./shipment-list.component.scss'],
  standalone: false
})
export class ShipmentListComponent implements OnInit {
  shipments: Shipment[] = [];
  displayedColumns: string[] = ['id', 'importerExporterName', 'productType', 'tax', 'status', 'actions'];

  constructor(private shipmentService: ShipmentService) {}

  ngOnInit(): void {
    this.loadShipments();
  }

  loadShipments(): void {
    this.shipmentService.getShipments().subscribe((data) => {
      this.shipments = data;
    });
  }

  deleteShipment(id: number): void {
    this.shipmentService.deleteShipment(id).subscribe(() => {
      this.loadShipments();
    });
  }
}
