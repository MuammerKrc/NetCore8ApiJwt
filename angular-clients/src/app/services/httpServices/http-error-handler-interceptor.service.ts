import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, firstValueFrom, from, of, switchMap, throwError } from 'rxjs';
import { Toast, ToastrService } from 'ngx-toastr';
import { AccountService, JWTokensDto } from 'src/generated_endpoints';
import { TokenStorageService } from '../authenticationServices/token-storage.service';
@Injectable({
  providedIn: 'root',


})
export class HttpErrorHandlerInterceptorService implements HttpInterceptor {

  constructor(private toastService:ToastrService,private accountService:AccountService,private tokenService:TokenStorageService) {}


  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log(req.headers);

    return next.handle(req).pipe(catchError(error=>{
      switch (error.status) {
        case HttpStatusCode.Unauthorized:
      return  of(this.refreshTokenMethod(req,next,this.tokenService.refreshToken));
        case 502:
          debugger;
          this.toastService.error(error.error.Message??"Bir hata meydana geldi");
        return of(error);
        default:
          this.toastService.error("Bir hata meydana geldi");
          return of(error);
      }
    }));

  }


  refreshTokenMethod(
    request: HttpRequest<any>,
    next: HttpHandler,
    refreshTokens: string
  ): Observable<HttpEvent<any>> {
    return from(this.accountService.accountLoginWithRefreshTokenPost({
      refreshToken:refreshTokens
    })).pipe(
      switchMap((res: JWTokensDto) => {
        debugger;
       console.log(refreshTokens);
       console.log(res);
        this.tokenService.setToken(res);
        request = request.clone({
          setHeaders: {
            Authorization: 'Bearer ' + res.accessToken,
          },
        });
        return next.handle(request);
      }),
      catchError((error) => {
        //Refresh Token Issue.
        if (error.status == 403) {
        }
        return throwError(() => error);
      })
    );
  }
}
