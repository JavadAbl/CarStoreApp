import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BASE_URL } from '../../constants';

@Injectable({
  providedIn: 'root',
})
export class UserServiceService {
  http = inject(HttpClient);
}
