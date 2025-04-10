import { Component, inject, signal } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { ActivatedRoute, RouterLinkActive } from '@angular/router';
import { EditCarDto } from '../../dtos/edit-car.dto';
import { CarService } from '../../services/car.service';
import { AppService } from '../../services/app.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-car',
  imports: [FormsModule],
  templateUrl: './edit-car.component.html',
  styleUrl: './edit-car.component.css',
})
export class EditCarComponent {
  carService = inject(CarService);
  toaster = inject(ToastrService);
  route = inject(ActivatedRoute);

  model: EditCarDto = {
    id: 0,
    name: '',
    price: 0,
    quantity: 0,
    description: '',
  };

  ngOnInit() {
    const carId = this.route.snapshot.params['id'];

    this.carService.getCar(carId).subscribe({
      next: (car) => {
        this.model = car;
      },
    });
  }

  handleSubmit(form: NgForm) {
    // console.log(form.value);

    this.carService.updateCar(this.model).subscribe({
      next: (v) => {
        this.toaster.success('Sucess');
      },
    });
  }
}
