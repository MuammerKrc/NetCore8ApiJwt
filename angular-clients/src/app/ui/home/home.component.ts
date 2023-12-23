import { Component } from '@angular/core';
import { AuthorizeService, ProductDto, ProductService } from 'src/generated_endpoints';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  productList:Array<ProductDto>=[];
  constructor(private service:AuthorizeService,private productService:ProductService){
    productService.productGetAllProdutsPost().subscribe(x=>{
      this.productList=x;
    })
  }

}
