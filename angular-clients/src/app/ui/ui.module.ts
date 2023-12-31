import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeModule } from './home/home.module';
import { ProductModule } from './product/product.module';
import { BasketsModule } from './baskets/baskets.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BasketsModule,
    HomeModule,
    ProductModule
  ],
  exports:[
    BasketsModule
  ]

})
export class UiModule { }
