import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private http: HttpClient) {}

  get(code: string) {

    if (code === undefined || code === "") {

      const getOptions = {
 
      }; 
      return this.http.get<Product[]>('api/product', getOptions)
        .pipe(
          map((response: Product[]) => {
            return response;
          }),
          catchError(this.handleError)
        );
    }
    else {
      const getOptions = {
        params: { code }
      };

      return this.http.get<Product[]>('api/product', getOptions)
        .pipe(
          map((response: Product[]) => {
            return response;
          }),
          catchError(this.handleError)
        );
    }
    
  }

  add(product: Product) {
    return this.http.post('api/product', product)
      .pipe(
        catchError(this.handleError)
      );
  }

  delete(product: Product) {
    return this.http.delete(`api/product/${product.id}`)
    .pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    console.error(error.message);
    return throwError('A data error occurred, please try again.');
  }
}

export interface Product {
  id: number;
  code: string;
  type: string;
}
/*
public class ProductComplexViewModel : ProductViewModel
{
        public IList < ProductViewModel > Parts { get; set; }
}
*/
