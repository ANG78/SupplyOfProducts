import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService, Product } from './product.service';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./list.component.css']
})
export class ProductListComponent implements OnInit {
  products: Product[];

  constructor(
    private service: ProductService,
    private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    this.activatedRoute.paramMap
      .subscribe(paramMap => {
        this.getProducts();
      });
  }

  onDelete(product: Product) {
    this.service.delete(product)
      .subscribe(() => {
        this.getProducts();
      });
  }

  onWatch(workPlace: Product) {
    this.service.delete(workPlace)
      .subscribe(() => {
        this.getProducts();
      });
  }

  getProducts() {
    this.service.get('')
      .subscribe(items => {
        this.products = items;
      });
  }
}
