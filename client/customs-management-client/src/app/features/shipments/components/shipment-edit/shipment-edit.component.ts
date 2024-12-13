import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShipmentService } from '../../../../core/services/shipment.service';
import { ShipmentUpdate } from '../../models/shipment-update.model';
import {FormsModule} from '@angular/forms';
import {MatFormField} from '@angular/material/form-field';
import {MatOption, MatSelect} from '@angular/material/select';

@Component({
  selector: 'app-shipment-edit',
  templateUrl: './shipment-edit.component.html',
  standalone:  false,
  styleUrls: ['./shipment-edit.component.scss']
})
export class ShipmentEditComponent implements OnInit {
  shipment: ShipmentUpdate = {
    id: 0,
    importerExporterName: '',
    productTypeId: 0,
    declaredValue: 0,
    status: 'Pending'
  };

  productTypes = [
    { id: 1, name: 'Electronic' },
    { id: 2, name: 'Food' },
    { id: 3, name: 'Textile' }
  ];

  constructor(
    private shipmentService: ShipmentService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.shipmentService.getShipmentById(id).subscribe((data) => {
      this.shipment = {
        id: data.id,
        importerExporterName: data.importerExporterName,
        productTypeId: this.productTypes.find(pt => pt.name === data.productType)?.id || 0,
        declaredValue: data.declaredValue,
        status: data.status
      };
    });
  }

  updateShipment(): void {
    this.shipmentService.updateShipment(this.shipment).subscribe(
      () => {
        this.router.navigate(['/shipments']);
      },
      (error) => {
        console.error('Güncelleme Hatası:', error);
      }
    );
  }

  cancel(): void {
    this.router.navigate(['/shipments']);
  }
}
