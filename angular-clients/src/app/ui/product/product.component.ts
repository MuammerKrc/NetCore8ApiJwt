import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductDto, ProductService } from 'src/generated_endpoints';
import { ProductListComponent } from './product-list/product-list.component';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from 'src/app/dialogs/delete-dialog/delete-dialog.component';
import { DialogsService } from 'src/app/services/common/dialogs.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent  implements OnInit {
  @ViewChild(ProductListComponent) productListViewChild:ProductListComponent;
  constructor(){}

  ngOnInit(): void {
  }
  
  createdProductfunc(product:ProductDto){
    this.productListViewChild.getProduct();
  }


}
