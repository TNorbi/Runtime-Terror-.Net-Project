import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  MovieData,
  MovieInterface,
  MoviesInterface,
} from '../models/MovieInterface';

@Injectable({
  providedIn: 'root',
})
export class MovieService {
  constructor(private http: HttpClient) {}
  allMoviesUrl = 'https://localhost:7234/api/Movies/get-all-movies';
  movieUrl = 'https://localhost:7234/api/Movies/get-movie-by-id';
  searchMoviesUrl = 'https://localhost:7234/api/Movies/get-movies-by-title';

  public getAllMovies(): Observable<MoviesInterface> {
    return this.http.get<any>(this.allMoviesUrl, {
      headers: new HttpHeaders().set('Content-Type', 'application/json'),
    });
  }

  public getMovie(id: number): Observable<MovieInterface> {
    const headerDict = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .append('id', id.toString());

    console.log(headerDict);
    return this.http.get<any>(this.movieUrl, {
      headers: headerDict,
    });
  }

  public searchMovies(keyword: string): Observable<MoviesInterface> {
    const headerDict = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .append('title', keyword);

    //console.log(headerDict);
    return this.http.get<any>(this.searchMoviesUrl, {
      headers: headerDict,
    });
  }
}
