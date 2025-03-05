import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { BASE_URL } from '../../constants';
import { LoginDto } from '../dtos/login.dto';
import { User } from '../models/user.model';
import { tap } from 'rxjs';
import { UserDto } from '../dtos/user.dto';
import { RegisterDto } from '../dtos/register.dto';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  http = inject(HttpClient);
  user = signal<User | null>(null);

  setUser(userDto: UserDto) {
    localStorage.setItem('token', userDto.token);
    this.user.set({ username: userDto.username });
  }

  register(loginDto: RegisterDto) {
    return this.http.post<UserDto>(BASE_URL + `user/register`, loginDto).pipe(
      tap((userDto) => {
        if (userDto) {
          this.setUser(userDto);
        }
      })
    );
  }

  login(loginDto: LoginDto) {
    return this.http.post<UserDto>(BASE_URL + `user/login`, loginDto).pipe(
      tap((userDto) => {
        if (userDto) {
          this.setUser(userDto);
        }
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    this.user.set(null);
  }
}
