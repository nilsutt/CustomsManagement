import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ShipmentService } from '../../../../core/services/shipment.service';
import {ShipmentCreate} from "../../models/shipment-create.model";

@Component({
    selector: 'app-shipment-create',
    templateUrl: './shipment-create.component.html',
    standalone: false,
    styleUrls: ['./shipment-create.component.scss']
})
export class ShipmentCreateComponent {
    shipment: ShipmentCreate = {
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
        private router: Router
    ) {}

    createShipment(): void {
        this.shipmentService.createShipment({
            importerExporterName: this.shipment.importerExporterName,
            productTypeId: this.shipment.productTypeId,
            declaredValue: this.shipment.declaredValue,
            status: this.shipment.status
        }).subscribe(
            () => {
                this.router.navigate(['/shipments']);
            },
            (error) => {
                console.error('API hatası:', error);
            }
        );
    }

    cancel(): void {
        this.router.navigate(['/shipments']);
    }
}
