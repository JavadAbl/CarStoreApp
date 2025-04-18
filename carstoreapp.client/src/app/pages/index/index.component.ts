import { Component } from '@angular/core';
import { NavbarComponent } from '../../components/navbar/navbar.component';
import { ProductGridComponent } from '../../components/product-grid/product-grid.component';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-index',
  imports: [NavbarComponent, RouterOutlet],
  templateUrl: './index.component.html',
  styleUrl: './index.component.css',
})
export class IndexComponent {}
