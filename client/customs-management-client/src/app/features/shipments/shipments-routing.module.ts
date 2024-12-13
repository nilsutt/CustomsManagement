import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipmentListComponent } from './components/shipment-list/shipment-list.component';
import { ShipmentEditComponent } from './components/shipment-edit/shipment-edit.component';
import { ShipmentCreateComponent } from './components/shipment-create/shipment-create.component';

const routes: Routes = [
  { path: '', component: ShipmentListComponent },
  { path: 'edit/:id', component: ShipmentEditComponent },
  { path: 'create', component: ShipmentCreateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShipmentsRoutingModule {}
