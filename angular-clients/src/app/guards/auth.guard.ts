import { Inject, inject } from '@angular/core';
import { CanActivate, CanActivateFn, Router } from '@angular/router';
import { TokenStorageService } from '../services/authenticationServices/token-storage.service';
import { JwtHelperService, JwtInterceptor } from '@auth0/angular-jwt';
import { UserAuthServiceService } from '../services/authenticationServices/user-auth-service.service';

export const AuthGuard: CanActivateFn = (route, state) => {
  var router =inject(Router);
  if(!inject(UserAuthServiceService).isAuthenticated) router.navigate(["auth"],{

    queryParams:{returnUrl:state.url}
  });

  return true;
};
