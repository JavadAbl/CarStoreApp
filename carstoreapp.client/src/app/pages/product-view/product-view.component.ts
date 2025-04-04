import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from '../../services/car.service';
import { Car } from '../../models/car.model';

@Component({
  selector: 'app-product-view',
  imports: [],
  templateUrl: './product-view.component.html',
  styleUrl: './product-view.component.css',
})
export class ProductViewComponent {
  carService = inject(CarService);
  route = inject(ActivatedRoute);
  router = inject(Router);
  car = signal<Car | null>(null);

  ngOnInit() {
    const carId = this.route.snapshot.paramMap.get('id');
    this.getCar(Number(carId));
  }

  private getCar(carId: number) {
    this.carService.getCar(carId).subscribe({
      next: (car) => this.car.set(car),
      // error: () => this.router.navigate(['/']),
    });
  }
}
