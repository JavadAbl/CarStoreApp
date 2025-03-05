import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { LoginDto } from '../../dtos/login.dto';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loginDto = signal<LoginDto>({ username: '1', password: '1' });
  userService = inject(UserService);

  login() {
    this.userService.login(this.loginDto()).subscribe({
      next(value) {
        console.log(value);
      },
    });
  }
}
