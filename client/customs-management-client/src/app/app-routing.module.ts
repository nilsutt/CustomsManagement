import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipmentListComponent } from './features/shipments/components/shipment-list/shipment-list.component';
import { ShipmentEditComponent } from './features/shipments/components/shipment-edit/shipment-edit.component';
import { ShipmentCreateComponent } from './features/shipments/components/shipment-create/shipment-create.component';
import { LayoutComponent } from './layout/layout.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', redirectTo: 'shipments', pathMatch: 'full' },
      { path: 'shipments', component: ShipmentListComponent },
      { path: 'shipment/create', component: ShipmentCreateComponent },
      { path: 'shipment/edit/:id', component: ShipmentEditComponent },
      { path: '**', redirectTo: 'shipments' }
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
