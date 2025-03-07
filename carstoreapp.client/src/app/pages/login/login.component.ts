import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { LoginDto } from '../../dtos/login.dto';
import { AjaxError } from 'rxjs/ajax';
import { HttpErrorResponse } from '@angular/common/http';
import { AppService } from '../../services/app.service';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loginDto = signal<LoginDto>({ username: null, password: null });
  userService = inject(UserService);
  appService = inject(AppService);

  login() {
    this.userService.login(this.loginDto()).subscribe({
      next(value) {
        console.log(value);
      },
      error: (err: any) => {
        this.appService.showErrorsToasts(err);
      },
    });
  }
}
