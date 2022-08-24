
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Injectable } from '@angular/core'
import { Observable } from 'rxjs';
import { UserInterface } from '../models/users/UsersInterface'

@Injectable({
  providedIn: 'root'
})

export class UsersService {
  constructor(private http: HttpClient) {
  }
  public getAllUsersData(): Observable<UserInterface> {
    return this.http.get<UserInterface>(
      'https://localhost:7234/api/Users/get-all-users',
      {
        headers: new HttpHeaders().set('Content-Type', 'application/json'),
      })
  }

}
