import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError } from 'rxjs';
import { AppService } from '../services/app.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const appService = inject(AppService);

  return next(req).pipe(
    catchError((error) => {
      appService.showErrorsToast(decodeErrorMessage(error));
      throw error;
    })
  );
};

function decodeErrorMessage(error: any): string {
  if (error instanceof HttpErrorResponse) {
    const errorBody = error.error;
    if (errorBody.message) {
      return errorBody.message;
    }

    if (errorBody.errors) {
      return errorBody.errors.map((error: any) => error).join('\n');
    }
  }

  return error.message || 'Unknown error';
}

/* function extractErrorMessages(error: HttpErrorResponse | Error): string[] {
  if (error instanceof Error) {
    return [error.message];
  }

  if (error instanceof HttpErrorResponse) {
    return [...error.error.errors];
  }
  return [];
} */
