import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WorkPlaceService {
  constructor(private http: HttpClient) {}

  get(code: string) {

    if (code === undefined || code === '') {

      const getOptions = {}; 
      return this.http.get<WorkPlace[]>('api/workPlace', getOptions)
        .pipe(
          map((response: WorkPlace[]) => {
            return response;
          }),
          catchError(this.handleError)
        );
    }
    else {
      const getOptions = {
        params: { code }
      };

      return this.http.get<WorkPlace[]>('api/workPlace', getOptions)
        .pipe(
          map((response: WorkPlace[]) => {
            return response;
          }),
          catchError(this.handleError)
        );
    }
    
  }

  add(workPlace: WorkPlace) {
    return this.http.post('api/workPlace', workPlace)
      .pipe(
        catchError(this.handleError)
      );
  }

  delete(workPlace: WorkPlace) {
    return this.http.delete(`api/workPlace/${workPlace.id}`)
    .pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    console.error(error.message);
    return throwError('A data error occurred, please try again.');
  }
}

export interface WorkPlace {
  id: number;
  code: string;
}
