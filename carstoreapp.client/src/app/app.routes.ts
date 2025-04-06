import { Routes } from '@angular/router';
import { IndexComponent } from './pages/index/index.component';
import { RegisterComponent } from './pages/register/register.component';
import { LoginComponent } from './pages/login/login.component';
import { NotfoundComponent } from './pages/notfound/notfound.component';
import { authGuard } from './guards/auth.guard';
import { ProductViewComponent } from './pages/product-view/product-view.component';
import { EditCarComponent } from './pages/edit-car/edit-car.component';

export const routes: Routes = [
  { path: '', component: IndexComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'car/:id', component: ProductViewComponent },
  { path: 'edit-car/:id', component: EditCarComponent },
  { path: '**', component: NotfoundComponent, pathMatch: 'full' },
];
