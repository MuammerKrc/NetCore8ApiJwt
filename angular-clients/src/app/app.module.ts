import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ApiModule, BASE_PATH, Configuration, ConfigurationParameters } from 'src/generated_endpoints';
import { UiModule } from './ui/ui.module';
import { AuthsModule } from './auths/auths.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    ApiModule.forRoot(apiConfigFactory),
    BrowserModule,
    AppRoutingModule,
    UiModule,
    AuthsModule,
    HttpClientModule
  ],
  providers: [
    { provide: BASE_PATH, useValue: 'http://localhost:5245' },
    // {
    //   provide: Configuration,
    //   useFactory: (authService: AuthService) => new Configuration(
    //     {
    //       accessToken: authService.getAccessToken.bind(authService)
    //     }
    //   ),
    //   deps: [AuthService],
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
