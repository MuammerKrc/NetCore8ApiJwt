import { Component } from '@angular/core';
import { AuthorizeService, WeatherForecastService } from 'src/generated_endpoints/index';
import { UserAuthServiceService } from './services/authenticationServices/user-auth-service.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-clients';
  constructor(public auth:UserAuthServiceService,private router:Router,private toastr:ToastrService){
    this.toastr.success('hello',"ben geldim",{
    });
  }

  signOut(){

    this.auth.signOut();
    this.router.navigateByUrl("/auth");
  }
}
