import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { catchError, delay } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if(error){
          if(error.status === 400){
            if(error.error.errors){
              throw error.error;  //throw the validation errors back to component that generated it eg test-error component
            }
            else{
              this.toastr.error(error.error.message, error.error.statusCode)
            }
          }
          if(error.status === 401){
            this.toastr.error(error.error.message, error.error.statusCode)
          }
          if(error.status === 404){
            this.router.navigateByUrl('/not-found');
          }
          if(error.status === 500){
            const navigationExtras: NavigationExtras = {state: { error: error.error }}; //passing the error state to another component eg server-error
            this.router.navigateByUrl('/server-error', navigationExtras); //the navigationExras are available in the constructor only
          }
        }
        return throwError(error);
      })
    );
  }
}
