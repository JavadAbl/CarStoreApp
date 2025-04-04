import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { constants } from '../../constants';
import { Car } from '../models/car.model';

@Injectable({
  providedIn: 'root',
})
export class CarService {
  private readonly BASE_URL = constants.BASE_URL;
  httpClient = inject(HttpClient);

  getCars() {
    return this.httpClient.get<Car[]>(`${this.BASE_URL}cars/GetALl`);
  }

  getCar(id: any) {
    return this.httpClient.get<Car>(`${this.BASE_URL}cars/${id}`);
  }

  constructor() {}
}
