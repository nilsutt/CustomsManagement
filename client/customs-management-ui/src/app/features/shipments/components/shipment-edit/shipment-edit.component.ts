import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShipmentService } from '../../../../core/services/shipment.service';
import { Shipment } from '../../models/shipment.model';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

@Component({
  standalone: false,
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule],
  selector: 'app-shipment-edit',
  templateUrl: './shipment-edit.component.html',
  styleUrls: ['./shipment-edit.component.scss'],
})
export class ShipmentEditComponent implements OnInit {
  shipment!: Shipment;

  constructor(
    private shipmentService: ShipmentService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.shipmentService.getShipmentById(id).subscribe((data) => {
      this.shipment = data;
    });
  }

  updateShipment(): void {
    this.shipmentService.updateShipmentStatus(this.shipment.id, this.shipment.status).subscribe(() => {
      this.router.navigate(['/shipments']);
    });
  }
}
