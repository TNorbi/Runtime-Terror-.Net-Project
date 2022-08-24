import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserInterface } from '../models/UserInterface';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}
  loginUrl = 'https://localhost:7234/api/Users/login';
  registerUrl = 'https://localhost:7234/api/Users/add-new-user';
  resetPasswordUrl = 'https://localhost:7234/api/Users/update-user-password';

  public loginUser(
    userName: string,
    password: string
  ): Observable<UserInterface> {
    var postData =
      '{"userName": "' + userName + '", "password": "' + password + '"}';
    return this.http.post<any>(this.loginUrl, postData, {
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
    });
  }

  public registerUser(
    userName: string,
    password: string,
    email: string,
    firstName: string,
    lastName: string
  ): Observable<UserInterface> {
    var postData =
      '{"userName": "' +
      userName +
      '", "password": "' +
      password +
      '", "email": "' +
      email +
      '", "firstName": "' +
      firstName +
      '", "lastName": "' +
      lastName +
      '"}';
    return this.http.post<any>(this.registerUrl, postData, {
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
    });
  }

  public resetPassword(userName: string, password: string, email: string) {
    var postData =
      '{"userName": "' +
      userName +
      '", "password": "' +
      password +
      '", "email": "' +
      email +
      '"}';
    return this.http.put<any>(this.resetPasswordUrl, postData, {
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
    });
  }
}
