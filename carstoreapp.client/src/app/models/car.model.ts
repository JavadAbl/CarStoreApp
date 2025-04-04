import { CarPhoto } from './car-photo.model';

export interface Car {
  id: number;
  name: string;
  description?: string;
  price: number;
  quantity: number;
  photos: CarPhoto[];
}
