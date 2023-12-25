import { Component, ViewChild } from '@angular/core';
import { UserAuthServiceService } from './services/authenticationServices/user-auth-service.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SignalRService } from './services/hubs/signalR.service';
import { ComponentType, DynamicComponentService } from './services/common/dynamic-component.service';
import { DynamicLoadComponentDirective } from './directives/dynamic-load-component.directive';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-clients';

  @ViewChild(DynamicLoadComponentDirective,{static:true}) dynamicLoadComponentDirective:DynamicLoadComponentDirective;

  constructor(public auth:UserAuthServiceService,private router:Router,private toastr:ToastrService,private signalR:SignalRService,private dynamicComponentService:DynamicComponentService){
    this.signalR.start("product-hub");

    this.signalR.on("productAdded",(recievedMessage)=>{
      console.log(recievedMessage);
    });

  }

  signOut(){
    this.auth.signOut();
    this.router.navigateByUrl("/auth");
  }

  async loadComponent(){
    await this.dynamicComponentService.loadComponent(ComponentType.BasketComponents,this.dynamicLoadComponentDirective.viewContainerRef);
  }
}
