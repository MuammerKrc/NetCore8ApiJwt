import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, firstValueFrom, of } from 'rxjs';
import { Toast, ToastrService } from 'ngx-toastr';
@Injectable({
  providedIn: 'root',


})
export class HttpErrorHandlerInterceptorService implements HttpInterceptor {

  constructor(private toastService:ToastrService) {}


  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log(req.headers);
    return next.handle(req).pipe(catchError(error=>{
      switch (error.status) {
        case HttpStatusCode.Unauthorized:

          break;
        case 502:

            break;
        default:
          this.toastService.error("Bir hata meydana geldi");
          break;
      }
      return of(error);
    }));
  }
}
