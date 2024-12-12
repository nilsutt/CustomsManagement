import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipmentListComponent } from './features/shipments/components/shipment-list/shipment-list.component';
import { ShipmentCreateComponent } from './features/shipments/components/shipment-create/shipment-create.component';
import { ShipmentEditComponent } from './features/shipments/components/shipment-edit/shipment-edit.component';

const routes: Routes = [
  { path: '', redirectTo: 'shipments', pathMatch: 'full' },
  { path: 'shipments', component: ShipmentListComponent },
  { path: 'shipments/create', component: ShipmentCreateComponent },
  { path: 'shipments/edit/:id', component: ShipmentEditComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
