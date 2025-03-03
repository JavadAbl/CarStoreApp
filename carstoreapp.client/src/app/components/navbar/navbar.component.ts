import { Component } from '@angular/core';
import {
  NgbCollapseModule,
  NgbDropdown,
  NgbDropdownModule,
} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-navbar',
  imports: [NgbCollapseModule, NgbDropdownModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {
  isMenuCollapsed = true;
}
