import { Component, OnInit } from '@angular/core';
import { ShipmentService } from '../../../../core/services/shipment.service';
import { Shipment } from '../../models/shipment.model';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import {RouterLink} from '@angular/router';
import {MatTable} from '@angular/material/table';

@Component({
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule, RouterLink, MatTable],
  selector: 'app-shipment-list',
  templateUrl: './shipment-list.component.html',
  styleUrls: ['./shipment-list.component.scss'],
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
