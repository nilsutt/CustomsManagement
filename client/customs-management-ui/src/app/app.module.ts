import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

import { AppRoutingModule } from './app-routing.module';
import { ShipmentCreateComponent } from './features/shipments/components/shipment-create/shipment-create.component';
import { HttpClientModule } from '@angular/common/http';
import {AppComponent} from './app.component';
import {ShipmentEditComponent} from './features/shipments/components/shipment-edit/shipment-edit.component';
import {ShipmentListComponent} from './features/shipments/components/shipment-list/shipment-list.component';
import {ShipmentService} from './core/services/shipment.service';

@NgModule({
  declarations: [
    AppComponent,
    ShipmentCreateComponent,
    ShipmentListComponent,
    ShipmentEditComponent,
    ShipmentService
  ],
  imports: [
    BrowserModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    AppRoutingModule,
    HttpClientModule,
    ShipmentCreateComponent,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

