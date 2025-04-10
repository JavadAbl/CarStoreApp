import { Component, inject } from '@angular/core';
import { CarService } from '../../services/car.service';
import { Car } from '../../models/car.model';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-product-grid',
  imports: [RouterLink],
  templateUrl: './product-grid.component.html',
  styleUrl: './product-grid.component.css',
})
export class ProductGridComponent {
  carService = inject(CarService);
  router = inject(Router);

  constructor() {
    if (this.carService.cars().length === 0)
      this.carService.getCars().subscribe();
  }

  ngOnInit() {}

  handleCarDetails(carId: number) {
    this.router.navigate(['/car', carId]);
  }
}
