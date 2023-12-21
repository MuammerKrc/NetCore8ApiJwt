import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductCreateComponent } from './product-create/product-create.component';
import { RouterModule } from '@angular/router';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import { ReactiveFormsModule } from '@angular/forms';
import { GeneralDeleteDirective } from 'src/app/directives/general-delete.directive';
import { DialogsModule } from 'src/app/dialogs/dialogs.module';

@NgModule({
  declarations: [
    ProductComponent,
    ProductListComponent,
    ProductCreateComponent,
    GeneralDeleteDirective
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([{path:"",component:ProductComponent}]),
    ReactiveFormsModule,
    MatTableModule,
    MatPaginatorModule,
    DialogsModule
  ]
})
export class ProductModule { }
