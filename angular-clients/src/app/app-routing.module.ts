import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './ui/home/home.component';
import { LayoutComponent } from './auths/layout/layout.component';
import { LoginComponent } from './auths/components/login/login.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {path:"",component:HomeComponent,canActivate:[AuthGuard]},
  {path:"product",loadChildren:()=>import("./ui/product/product.module").then(x=>x.ProductModule),canActivate:[AuthGuard]},
  {path:"auth",component:LayoutComponent,children:[
    {path:"",component:LoginComponent},
    {path:"register",loadChildren:()=>import("./auths/components/register/register.module").then(module=>module.RegisterModule)}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
