import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShipmentsRoutingModule } from './shipments-routing.module';
import { ShipmentListComponent } from './components/shipment-list/shipment-list.component';
import { ShipmentEditComponent } from './components/shipment-edit/shipment-edit.component';
import { ShipmentCreateComponent } from './components/shipment-create/shipment-create.component';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import {MatPaginator} from '@angular/material/paginator';
import {MatToolbar} from '@angular/material/toolbar';
import {MatChip} from '@angular/material/chips';
import {MatIcon} from '@angular/material/icon';

@NgModule({
  declarations: [
    ShipmentListComponent,
    ShipmentEditComponent,
    ShipmentCreateComponent,
  ],
  imports: [
    CommonModule,
    ShipmentsRoutingModule,
    FormsModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatPaginator,
    MatToolbar,
    MatChip,
    MatIcon,
  ],
  exports: [
    ShipmentListComponent,
    ShipmentEditComponent,
    ShipmentCreateComponent,
  ],
})
export class ShipmentModule {}
