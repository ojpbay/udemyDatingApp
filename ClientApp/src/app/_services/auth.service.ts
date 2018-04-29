import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthService {
  baseUrl = 'http://localhost:2903/api/auth/';
  userToken: any; 

  constructor(private http: HttpClient) { }

  login(model: any) {
    
    return this.http.post<any>(this.baseUrl + 'login', model, this.generateOptions())
      .map((response) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.tokenString);
          this.userToken = user.tokenString;
        }
      }).catch(this.handleError);
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model, this.generateOptions()).catch(this.handleError);
  }

  private generateOptions() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
  }

  private handleError(error: any) {
    debugger;
    const applicationError = error.headers.get('Application-Error');
    if (applicationError) {
      return Observable.throw(applicationError);
    }

    const serverError = error.error;
    let modelStateErrors = '';
    if (serverError) {
      for (const key in serverError) {
        if (serverError[key]) {
          modelStateErrors += serverError[key] + '\n';
        }
      }

      return Observable.throw(
        modelStateErrors || 'Server error'
      );
    }
  }
}
