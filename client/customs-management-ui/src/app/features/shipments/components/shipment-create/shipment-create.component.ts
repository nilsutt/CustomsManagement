import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ShipmentService } from '../../../../core/services/shipment.service';
import { Shipment } from '../../models/shipment.model';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

@Component({
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule],
  selector: 'app-shipment-create',
  templateUrl: './shipment-create.component.html',
  styleUrls: ['./shipment-create.component.scss'],
})

export class ShipmentCreateComponent {
  shipment: Shipment = {
    id: 0,
    importerExporterName: '',
    productType: '',
    declaredValue: 0,
    tax: 0,
    status: 'Pending',
    createdDate: new Date(),
  };

  constructor(private shipmentService: ShipmentService, private router: Router) {}

  saveShipment(): void {
    this.shipmentService.createShipment(this.shipment).subscribe(() => {
      this.router.navigate(['/shipments']);
    });
  }
}
