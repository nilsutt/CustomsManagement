import { Component } from '@angular/core';
import {Router, RouterOutlet} from '@angular/router';
import { ShipmentService } from '../../../src/app/core/services/shipment.service';
import {MatSidenavContainer} from '@angular/material/sidenav';
import {MatToolbar} from '@angular/material/toolbar';
import {MatNavList} from '@angular/material/list';
import {MatIcon} from '@angular/material/icon';
@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
  standalone: false,
})

export class LayoutComponent {
  constructor(
    private router: Router
  ) {}

  createAndRedirect(): void {
    this.router.navigate(['/shipment/create']);
  }
}
