import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketsComponent } from './baskets.component';
import { DynamicLoadComponentDirective } from 'src/app/directives/dynamic-load-component.directive';



@NgModule({
  declarations: [
    BasketsComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    BasketsComponent,

  ]
})
export class BasketsModule { }
