import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductDto, ProductService } from 'src/generated_endpoints';
import { ProductListComponent } from './product-list/product-list.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent  implements OnInit {

  @ViewChild(ProductListComponent) productListViewChild:ProductListComponent;

  constructor(private productService:ProductService){}
  ngOnInit(): void {
    this.productService.productGetAllProdutsGet().subscribe(x=>{
      console.log(x);
    })
  }
  createdProductfunc(product:ProductDto){
    this.productListViewChild.getProduct();

  }
}
