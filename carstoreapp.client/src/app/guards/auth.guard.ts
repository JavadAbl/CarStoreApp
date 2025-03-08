import { inject } from '@angular/core';
import { CanMatchFn } from '@angular/router';
import { UserService } from '../services/user.service';

export const authGuard: CanMatchFn = (route, state) => {
  const userService = inject(UserService);

  if (userService.user()) return true;
  else return false;
};
