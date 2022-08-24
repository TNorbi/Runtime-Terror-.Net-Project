import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MoviesInterface } from '../models/MovieInterface';
import { UserInterface } from '../models/UserInterface';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  public users!: UserInterface;
  public displayForm = false;
  public _userName!: string;
  public loginButton: boolean = true;
  public inputValue = '';
  public _moviesData!: MoviesInterface;

  set userName(value: string) {
    this._userName = value;
  }

  get userName(): string {
    return this._userName;
  }

  set moviesData(value: MoviesInterface) {
    this._moviesData = value;
    if (value.code === 200) {
      //this._moviesData.emit();
      console.log('Movies have arrived TO UPCOMING MOVIES successfully');
    }
  }

  get moviesData(): MoviesInterface {
    return this._moviesData;
  }

  constructor(private movieService: MovieService, private router: Router) {}
  ngOnInit(): void {}

  public toggleSingIn(event?: any): void {
    this.displayForm = !this.displayForm;
  }

  loginSuccessful(success: string) {
    this.userName = success;
    this.loginButton = false;
  }

  modalClosed(isClosed: boolean) {
    this.displayForm = isClosed;
  }

  searchMovies(inputValue: string) {
    this.movieService.searchMovies(inputValue).subscribe((data) => {
      this.moviesData = data;
      console.log(this.moviesData);
    });
    setTimeout(() => {
      // <<<---using ()=> syntax
      const nr = Number(this.moviesData.movieList![0].mov_Id) - 1;
      this.router.navigateByUrl('/home/movie-details?movieNr=' + nr, {
        replaceUrl: true,
      });
    }, 500);
  }
  title = 'Runtime-terror';
}
