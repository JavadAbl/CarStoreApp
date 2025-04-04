import { Component, HostListener, inject, viewChildren } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-edit-user',
  imports: [],
  templateUrl: './edit-user.component.html',
  styleUrl: './edit-user.component.css',
})
export class EditUserComponent {
  userService = inject(UserService);
  user = this.userService.user;
  @HostListener('window:beforeunload', ['$event'])
  onResize(event: Event) {
    // Handle the resize event
  }

  constructor() {}
}
