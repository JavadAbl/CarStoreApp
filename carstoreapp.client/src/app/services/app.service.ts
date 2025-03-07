import { HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  private toaster = inject(ToastrService);

  showErrorsToasts(error: any) {
    const errorMessages = this.extractErrorMessages(error);

    errorMessages.forEach((errorMessage) => {
      this.toaster.error(errorMessage);
    });
  }

  private extractErrorMessages(error: HttpErrorResponse | Error): string[] {
    if (error instanceof Error) {
      return [error.message];
    }

    if (error instanceof HttpErrorResponse) {
      return [...error.error.errors];
    }
    return [];
  }
}
