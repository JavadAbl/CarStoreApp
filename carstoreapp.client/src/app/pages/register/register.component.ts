import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { RegisterDto } from '../../dtos/register.dto';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  registerDto = signal<RegisterDto>({ username: '1', password: '1' });
  userService = inject(UserService);

  handleRegister() {
    this.userService.login(this.registerDto()).subscribe({
      next(value) {
        console.log(value);
      },
    });
  }
}
