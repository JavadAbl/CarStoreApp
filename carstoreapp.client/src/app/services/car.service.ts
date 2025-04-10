import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { constants } from '../../constants';
import { Car } from '../models/car.model';
import { EditCarDto } from '../dtos/edit-car.dto';
import { of, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  private readonly BASE_URL = constants.BASE_URL;
  httpClient = inject(HttpClient);
  cars = signal<Car[]>([]);

  getCars() {
    return this.httpClient.get<Car[]>(`${this.BASE_URL}cars/GetALl`).pipe(
      tap((cars) => {
        this.cars.set(cars);
      })
    );
  }

  getCar(id: any) {
    // Check if car is already in the cache
    const car = this.cars().find((c) => c.id === id);
    if (car) return of(car);

    return this.httpClient.get<Car>(`${this.BASE_URL}cars/${id}`);
  }

  updateCar(editCarDto: EditCarDto) {
    return this.httpClient
      .put<Car>(`${this.BASE_URL}cars/Update`, editCarDto)
      .pipe(
        tap((car) => {
          // Update the car in the cache

          this.cars.update((cars) =>
            cars.map((c) => (c.id === car.id ? car : c))
          );
        })
      );
  }
}
