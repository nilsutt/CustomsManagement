import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';

import { ShipmentListComponent } from './components/shipment-list/shipment-list.component';
import { ShipmentCreateComponent } from './components/shipment-create/shipment-create.component';
import { ShipmentEditComponent } from './components/shipment-edit/shipment-edit.component';

@NgModule({
  declarations: [
    ShipmentListComponent,
    ShipmentCreateComponent,
    ShipmentEditComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatTableModule,
    RouterModule
  ],
  exports: [
    ShipmentListComponent,
    ShipmentCreateComponent,
    ShipmentEditComponent
  ]
})
export class ShipmentModule {}
