import { Component, Input, OnInit } from '@angular/core';
import { MoviesInterface } from 'src/app/models/MovieInterface';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css'],
})
export class MovieComponent implements OnInit {
  _moviesData!: MoviesInterface;

  set moviesData(value: MoviesInterface) {
    this._moviesData = value;
    console.log(value);
    if (value.code === 200) {
      //this._moviesData.emit();
      console.log('Movies have arrived TO UPCOMING MOVIES successfully');
    }
  }

  get moviesData(): MoviesInterface {
    return this._moviesData;
  }
  constructor(private movieService: MovieService) {}

  ngOnInit(): void {
    this.movieService.getAllMovies().subscribe((data) => {
      this.moviesData = data;
    });
  }
}
