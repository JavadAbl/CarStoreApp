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
  cars: Car[] = [];

  ngOnInit() {
    this.carService.getCars().subscribe((cars) => (this.cars = cars));
  }

  handleCarDetails(carId: number) {
    this.router.navigate(['/car', carId]);
  }
}
