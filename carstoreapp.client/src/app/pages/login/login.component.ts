import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { LoginDto } from '../../dtos/login.dto';
import { AjaxError } from 'rxjs/ajax';
import { HttpErrorResponse } from '@angular/common/http';
import { AppService } from '../../services/app.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loginDto = signal<LoginDto>({ username: null, password: null });
  router = inject(Router);
  userService = inject(UserService);
  appService = inject(AppService);

  login() {
    this.userService.login(this.loginDto()).subscribe({
      next: (_) => {
        this.router.navigateByUrl('', { replaceUrl: true });
      },
      error: (err: any) => {
        this.appService.showErrorsToasts(err);
      },
    });
  }
}
