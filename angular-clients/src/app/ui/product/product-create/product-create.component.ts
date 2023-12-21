import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProductDto, ProductService } from 'src/generated_endpoints';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent  {
  product:ProductDto={};
  constructor(private productService:ProductService){
    }
    @Output() createdProductEvent :EventEmitter<any>=new EventEmitter<ProductDto>;
    
  onSubmit($event:MouseEvent,txtName:HTMLInputElement,txtStock:HTMLInputElement,txtPrice:HTMLInputElement){
    $event.preventDefault();
    this.product.name=txtName.value;
    this.product.price=Number.parseFloat(txtPrice.value);
    this.product.stock=Number.parseInt(txtStock.value);
    this.productService.productCreateProductPost(this.product).subscribe(p=>{
      this.createdProductEvent.emit(this.product);
    });
  }

}
