import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, catchError, retry } from 'rxjs/operators';

import { Observable } from 'rxjs';
import { HandledError } from 'src/app/Shared/Model/Error/handled-error';
import { UnHandledError } from 'src/app/Shared/Model/Error/unhandled-error';
// @Injectable({
//   providedIn: 'root'
// })
export class ApiService {

  constructor(private http: HttpClient, private apiUrl: string) { }

get(url: string) {
  return this.http.get(this.apiUrl + url).pipe(
    map(x => this.responseHandler(x)),
    retry(1),
    catchError(x => this.responseHandler(x))
  );
}
post(url: string, data: any) {
  return this.http.post(this.apiUrl + url, data).pipe(
    map(x => this.responseHandler(x)),
    catchError(x => this.responseHandler(x))
  );

}
private responseHandler(x: any) {
  if (x.hasOwnProperty('didError') && !x['didError']) {
    return x['model'];
  } else {
    this.errorHandler(x);
  }
}
private errorHandler(x: any) {
  if (x.hasOwnProperty('errorMessage') && !x['errorMessage']) {
    throw new HandledError(x['errorMessage']);
  } else {
    throw new UnHandledError('unhandled error');
  }
}
getWithParams(route: string, paramsdata: HttpParams): Observable<any> {
  const url = `${this.apiUrl}/${route}`;
  return this.http.get(url, { params: paramsdata }).pipe(
    map(x => {
      // return x;
      // x=x["model"];
      if (!x["didError"]) {
        return x["model"];
      } else {
        // return Observable.throw(x["errorMessage"]);
        if (!x["errorMessage"]) {
          throw x["errorMessage"];
        } else {
          throw new Error('unhandled error');
        }
        // return throwError(new Error(x["errorMessage"]));
      }
    }),
    retry(1),
    catchError(
      (error: any, caught: Observable<any>) => {
        // if (error.status === 401) {
        //this.handleAuthError();
        throw error;
      }
    )
  );
}
public getJSON(path: string): Observable<any> {
  return this.http.get(path);
}
put(url: string, data: any) {
  return this.http.put(this.apiUrl + url, data).pipe(
    map(x => this.responseHandler(x)),
    retry(1),
    catchError(x => this.responseHandler(x))
  );
}
}