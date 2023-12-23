import { Component } from '@angular/core';
import { AuthorizeService, ProductService, WeatherForecastService } from 'src/generated_endpoints/index';
import { UserAuthServiceService } from './services/authenticationServices/user-auth-service.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SignalRService } from './services/hubs/signalR.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-clients';
  constructor(public auth:UserAuthServiceService,private router:Router,private toastr:ToastrService,private signalR:SignalRService){
    this.signalR.start("product-hub");

    this.signalR.on("productAdded",(recievedMessage)=>{
      console.log(recievedMessage);
    });

  }

  signOut(){
    this.auth.signOut();
    this.router.navigateByUrl("/auth");
  }
}
