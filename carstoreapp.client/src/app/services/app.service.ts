import { HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  private toaster = inject(ToastrService);

  showErrorsToast(error: string) {
    this.toaster.error(error);
  }
}
