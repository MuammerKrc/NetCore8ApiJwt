import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TokenStorageService } from './token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class UserAuthServiceService {

  constructor(private jwtHelperService:JwtHelperService,
    private tokenStorageService:TokenStorageService) {}
    private accessToken=this.tokenStorageService.accessToken;

    get isAuthenticated():boolean{
      return  !this.jwtHelperService.isTokenExpired(this.accessToken);
    }
}
