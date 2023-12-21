import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ProductDto, ProductService } from 'src/generated_endpoints';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements AfterViewInit,OnInit {
    constructor(private productService:ProductService) {
    }

    displayedColumns: string[] = ['name', 'stock', 'price','edit','delete'];
    dataSource = new MatTableDataSource<ProductDto>([]);

    @ViewChild(MatPaginator) paginator: MatPaginator;
    ngOnInit(): void {
      this.productService.productGetAllProdutsGet().subscribe(products=>{
        this.dataSource.data=products;
      });
    }
    getProduct(){
      this.productService.productGetAllProdutsGet().subscribe(products=>{
        this.dataSource.data=products;
      });
    }
    ngAfterViewInit() {
      this.dataSource.paginator = this.paginator;
    }
  }

