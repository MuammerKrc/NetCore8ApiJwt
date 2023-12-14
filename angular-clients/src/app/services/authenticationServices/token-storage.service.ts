import { Injectable } from '@angular/core';
import { JWTokensDto } from 'src/generated_endpoints';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  get accessToken():string | null {
    return localStorage.getItem("accessToken");
  }
  get refreshToken():string | null{
    return localStorage.getItem("refreshToken");
  }

  setToken(jwtTokens:JWTokensDto){
    localStorage.setItem("accessToken",jwtTokens.accessToken);
    localStorage.setItem("refreshToken",jwtTokens.refreshToken);
  }
  removeToken(){
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
  }
}
