import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ApiModule, BASE_PATH, Configuration, ConfigurationParameters } from 'src/generated_endpoints';
import { UiModule } from './ui/ui.module';
import { AuthsModule } from './auths/auths.module';
import { JwtModule } from '@auth0/angular-jwt';
import { TokenStorageService } from './services/authenticationServices/token-storage.service';
import { ToastrModule } from 'ngx-toastr';
import { HttpErrorHandlerInterceptorService } from './services/httpServices/http-error-handler-interceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    ApiModule.forRoot(apiConfigFactory),
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    UiModule,
    AuthsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    JwtModule.forRoot({
      config:{
        tokenGetter:()=>localStorage.getItem("accessToken"),
        allowedDomains:["localhost:5245"],
      }
    }),
  ],
  providers: [

    { provide: BASE_PATH, useValue: 'http://localhost:5245' },
    {provide:HTTP_INTERCEPTORS,useClass:HttpErrorHandlerInterceptorService,multi:true},
    // {
    //   provide: Configuration,
    //   useFactory: (authService: TokenStorageService) => new Configuration(
    //     {
    //       accessToken: authService.accessToken
    //     }
    //   ),
    //   deps: [TokenStorageService],
    //   multi: false
    // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
export function apiConfigFactory (): Configuration {
  const params: ConfigurationParameters = {
    // set configuration parameters here.
  }
  return new Configuration(params);
}
