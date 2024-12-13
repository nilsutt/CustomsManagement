import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { ShipmentService } from '../../../../core/services/shipment.service';
import { Shipment } from '../../models/shipment.model';

@Component({
  selector: 'app-shipment-list',
  templateUrl: './shipment-list.component.html',
  standalone: false,
  styleUrls: ['./shipment-list.component.scss']
})
export class ShipmentListComponent implements OnInit {
  shipments: Shipment[] = [];
  displayedColumns: string[] = [
    'id',
    'importerExporterName',
    'productType',
    'declaredValue',
    'tax',
    'totalValue',
    'status',
    'actions'
  ];
  dataSource: MatTableDataSource<Shipment> = new MatTableDataSource();

  selectedStatus: string = 'all'; // Varsayılan olarak "Hepsi" seçili
  delayedDays: number | null = null; // Gecikme gün sayısı

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private shipmentService: ShipmentService) {}

  ngOnInit(): void {
    this.loadShipments();
  }

  loadShipments(): void {
    this.shipmentService.getShipments().subscribe((data) => {
      this.dataSource.data = data;
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }

  applyFilter(): void {
    // API'ye filtrelenmiş istek gönder
    this.shipmentService
      .getShipments(this.selectedStatus === 'all' ? undefined : this.selectedStatus, this.delayedDays || undefined)
      .subscribe((data) => {
        this.dataSource.data = data;
      });
  }

  deleteShipment(id: number): void {
    this.shipmentService.deleteShipment(id).subscribe(() => {
      this.loadShipments();
    });
  }
}
