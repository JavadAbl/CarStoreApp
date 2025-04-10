import { Routes } from '@angular/router';
import { IndexComponent } from './pages/index/index.component';
import { RegisterComponent } from './pages/register/register.component';
import { LoginComponent } from './pages/login/login.component';
import { NotfoundComponent } from './pages/notfound/notfound.component';
import { ProductViewComponent } from './pages/product-view/product-view.component';
import { EditCarComponent } from './pages/edit-car/edit-car.component';
import { ProductGridComponent } from './components/product-grid/product-grid.component';

export const routes: Routes = [
  {
    path: '',
    component: IndexComponent,
    children: [
      { path: '', component: ProductGridComponent },
      { path: 'car/:id', component: ProductViewComponent },
      { path: 'edit-car/:id', component: EditCarComponent },
    ],
  },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', component: NotfoundComponent, pathMatch: 'full' },
];
