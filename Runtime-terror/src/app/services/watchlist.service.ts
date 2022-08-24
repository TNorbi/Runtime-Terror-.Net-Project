import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  WatchListForAllMoviesInterface,
  WatchListInterface,
} from '../models/WatchListInterface';

@Injectable({
  providedIn: 'root',
})
export class WatchListService {
  addToWatchlistURL =
    'https://localhost:7234/api/Watchlist/add-movie-to-watchlist';
  removeFromWatchListURL =
    'https://localhost:7234/api/Watchlist/delete-movie-from-watchlist';
  getUserWatchlistURL =
    'https://localhost:7234/api/Watchlist/get-user-watchlist-by-id';
  constructor(private http: HttpClient) {}

  public addToWatchlist(
    userID: number,
    movieID: number
  ): Observable<WatchListInterface> {
    var postData = '{"userID": "' + userID + '", "movieID": "' + movieID + '"}';
    return this.http.post<any>(this.addToWatchlistURL, postData, {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json')
        .append('accept', '*/*'),
    });
  }
  public removeFromWatchlist(
    userID: number,
    movieID: number
  ): Observable<WatchListInterface> {
    var postData = '{"userID": "' + userID + '", "movieID": "' + movieID + '"}';
    return this.http.post<any>(this.removeFromWatchListURL, postData, {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json')
        .append('accept', '*/*'),
    });
  }

  public getUserWatchlistById(
    userId: number
  ): Observable<WatchListForAllMoviesInterface> {
    const headerDict = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .append('userID', userId.toString())
      .append('accept', '*/*');

    //console.log(headerDict);
    return this.http.get<any>(this.getUserWatchlistURL, {
      headers: headerDict,
    });
  }
}
