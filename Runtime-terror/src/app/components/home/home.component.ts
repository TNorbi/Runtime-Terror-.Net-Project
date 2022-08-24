import { Component, Input, OnInit } from '@angular/core';
import { MoviesInterface } from 'src/app/models/MovieInterface';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  _moviesData!: MoviesInterface;

  set moviesData(value: MoviesInterface) {
    this._moviesData = value;
    console.log(value);
    if (value.code === 200) {
      //this._moviesData.emit();
      console.log('Movies have arrived successfully');
    }
  }

  get moviesData(): MoviesInterface {
    return this._moviesData;
  }

  constructor(private movieService: MovieService) {}
  ngOnInit(): void {
    //     this.usersService.getAllUsersData().subscribe((data) => {
    //       this.users = data;
    //       console.log(this.users)
    // })

    this.movieService.getAllMovies().subscribe((data) => {
      this.moviesData = data;
    });
  }
}
