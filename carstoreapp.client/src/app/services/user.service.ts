import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { BASE_URL } from '../../constants';
import { LoginDto } from '../dtos/login.dto';
import { User } from '../models/user.model';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  http = inject(HttpClient);
  user = signal<User | null>(null);

  setUser(value) {}
  login(loginDto: LoginDto) {
    return this.http.post(BASE_URL + `user/login`, loginDto).pipe(
      tap((response) => {
        this.setUser(response); // Set the user based on the response
      })
    );
  }
}
