import { Component, inject } from '@angular/core';
import {
  NgbCollapseModule,
  NgbDropdown,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-navbar',
  imports: [NgbCollapseModule, NgbDropdownModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {
  isMenuCollapsed = true;
  userService = inject(UserService);

  handleLogout() {
    this.userService.logout();
  }
}
