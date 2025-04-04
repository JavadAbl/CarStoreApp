import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { LoginDto } from '../dtos/login.dto';
import { User } from '../models/user.model';
import { tap } from 'rxjs';
import { RegisterDto } from '../dtos/register.dto';
import { ActivatedRoute, Router } from '@angular/router';
import { UserDto } from '../dtos/user.dto';
import { constants } from '../../constants';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly BASE_URL = constants.BASE_URL;
  http = inject(HttpClient);
  user = signal<User | null>(null);
  isLoggedIn = signal<boolean>(false);
  router = inject(Router);

  /*  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.http
        .get<UserDto>(BASE_URL + `user/me`, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .pipe(
          tap((userDto) => {
            if (userDto) {
              this.setUser(userDto);
              this.isLoggedIn.set(true);
            }
          })
        )
        .subscribe();
    } else {
      this.isLoggedIn.set(false);
    }
  } */

  private setUser(userDto: UserDto) {
    localStorage.setItem('token', userDto.token);
    this.user.set(userDto);
  }

  register(loginDto: RegisterDto) {
    return this.http
      .post<UserDto>(this.BASE_URL + `user/register`, loginDto)
      .pipe(
        tap((userDto) => {
          if (userDto) {
            this.setUser(userDto);
          }
        })
      );
  }

  login(loginDto: LoginDto) {
    return this.http.post<UserDto>(this.BASE_URL + `user/login`, loginDto).pipe(
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
    this.router.navigateByUrl('login', { replaceUrl: true });
  }
}
