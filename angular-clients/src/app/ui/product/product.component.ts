import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/generated_endpoints';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent  implements OnInit {
  constructor(private productService:ProductService){}
  ngOnInit(): void {
    this.productService.productGetAllProdutsGet().subscribe(x=>{
      console.log(x);
    })
  }
}
