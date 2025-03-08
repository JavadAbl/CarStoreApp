import { Routes } from '@angular/router';
import { IndexComponent } from './pages/index/index.component';
import { RegisterComponent } from './pages/register/register.component';
import { LoginComponent } from './pages/login/login.component';
import { NotfoundComponent } from './pages/notfound/notfound.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', component: IndexComponent, canMatch: [authGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', component: NotfoundComponent, pathMatch: 'full' },
];
