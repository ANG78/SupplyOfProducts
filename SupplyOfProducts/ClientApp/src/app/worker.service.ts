import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WorkerService {
  constructor(private http: HttpClient) { }

  get(code: string) {

    const getOptions = {};
    if (code === undefined || code === "") {

      return this.http.get<Worker[]>('api/worker', getOptions)
        .pipe(
          map((response: Worker[]) => {
            return response;
          }),
          catchError(this.handleError)
        );
    }
    else {

      return this.http.get<Worker>(`api/worker/${code}`, getOptions)
        .pipe(
          map((response: Worker) => {
            let result: any[] = [response] ; 
            return result;
          }),
          catchError(this.handleError)
        );
    }

  } 

  add(worker: Worker) {
    return this.http.post('api/worker', worker, { responseType: 'text' })
      .pipe(
        catchError(this.handleError)
      );
  }

  delete(worker: Worker) {
    return this.http.delete(`api/worker/${worker.id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    alert(error.message);
    return throwError('A data error occurred, please try again.');
  }
}

interface WorkersResponse {
  workes: Worker[];
}

export interface Worker {
  id: number;
  code: string;
  name: string;
}
