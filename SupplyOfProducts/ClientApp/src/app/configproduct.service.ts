import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConfigProductService {
  constructor(private http: HttpClient) {}

  get(code: string) {

    if (code === undefined || code === "") {

      const getOptions = {
 
      }; 
      return this.http.get<ConfigProduct[]>('api/configProduct', getOptions)
        .pipe(
          map((response: ConfigProduct[]) => {
            return response;
          }),
          catchError(this.handleError)
        );
    }
    else {
      const getOptions = {
        params: { code }
      };

      return this.http.get<ConfigProduct[]>('api/configProduct', getOptions)
        .pipe(
          map((response: ConfigProduct[]) => {
            return response;
          }),
          catchError(this.handleError)
        );
    }
    
  }

  add(configProduct: ConfigProduct) {
    return this.http.post('api/configProduct', configProduct)
      .pipe(
        catchError(this.handleError)
      );
  }

  delete(configProduct: ConfigProduct) {
    return this.http.delete(`api/configProduct/${configProduct.id}`)
    .pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    console.error(error.message);
    return throwError('A data error occurred, please try again.');
  }
}

export interface ConfigProduct {
  id: number;
  code: string;
}
