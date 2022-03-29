import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../environments/environment';
import { Observable, of, throwError, Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseOut } from 'src/models/base/BaseOut';
import { Result } from 'src/models/base/Result';
@Injectable({
  providedIn: 'root'
})
export class BaseService {
  protected _baseUrl: string;
  public _http: HttpClient;
  protected _onUnauthorizedRequest: EventEmitter<any>;

  constructor(protected http: HttpClient, protected router: Router) {
    this._http = http;
    this._baseUrl = environment.ApiUrl;
    this._onUnauthorizedRequest = new EventEmitter<any>();
  }

  executeGet(relativeUrl: string, params? :HttpParams): any {
    const url = `${this._baseUrl + relativeUrl}`;
    return this.http.get(url, { headers: this.headers, params: params }).pipe(
      catchError(error => {
        let errorMsg: string;
        if (error.error instanceof ErrorEvent) {
          errorMsg = `Error: ${error.error.message}`;
        } else {
          errorMsg = this.getServerErrorMessage(error);
        }

        const baseOut = new BaseOut();
        baseOut.result = Result.ConnectionApiError;
        baseOut.message = errorMsg;
        return of(baseOut);
      })
    );
  }

  get headers(): HttpHeaders {
    return new HttpHeaders({
        'ApiKey': environment.ApiKey,
        'Content-Type': 'application/json'
      });
  }

  private getServerErrorMessage(error: HttpErrorResponse): string {
    switch (error.status) {
      case 404: {
        return `Not Found: ${error.message}`;
      }
      case 403: {
        return `Access Denied: ${error.message}`;
      }
      case 500: {
        return `Internal Server Error: ${error.message}`;
      }
      default: {
        return `Unknown Server Error: ${error.message}`;
      }
    }
  }
}
