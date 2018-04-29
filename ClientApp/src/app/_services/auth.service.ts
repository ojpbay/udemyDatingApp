import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import 'rxjs/add/operator/map';

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
      })
  }

  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model, this.generateOptions());
  }

  private generateOptions() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
  }
}
