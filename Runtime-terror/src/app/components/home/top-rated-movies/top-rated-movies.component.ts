import { Component, Input, OnInit } from '@angular/core';
import { GlobalConstants } from 'src/app/common/global-constants';
import { MoviesInterface } from 'src/app/models/MovieInterface';

@Component({
  selector: 'app-top-rated-movies',
  templateUrl: './top-rated-movies.component.html',
  styleUrls: ['./top-rated-movies.component.css'],
})
export class TopRatedMoviesComponent implements OnInit {
  _moviesData!: MoviesInterface;

  @Input() set moviesData(value: MoviesInterface) {
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
  constructor() {}

  ngOnInit(): void {}
}
