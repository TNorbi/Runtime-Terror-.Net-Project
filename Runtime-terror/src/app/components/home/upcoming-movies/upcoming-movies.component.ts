import { Component, Input, OnInit } from '@angular/core';
import { MoviesInterface } from 'src/app/models/MovieInterface';

@Component({
  selector: 'app-upcoming-movies',
  templateUrl: './upcoming-movies.component.html',
  styleUrls: ['./upcoming-movies.component.css'],
})
export class UpcomingMoviesComponent implements OnInit {
  _moviesData!: MoviesInterface;

  posterlinks = [
    '../../../../assets/img/poster/ucm_poster01.jpg',
    '../../../../assets/img/poster/ucm_poster02.jpg',
    '../../../../assets/img/poster/ucm_poster03.jpg',
    '../../../../assets/img/poster/ucm_poster04.jpg',
    '../../../../assets/img/poster/ucm_poster05.jpg',
    '../../../../assets/img/poster/ucm_poster06.jpg',
    '../../../../assets/img/poster/ucm_poster07.jpg',
    '../../../../assets/img/poster/ucm_poster08.jpg',
    '../../../../assets/img/poster/ucm_poster09.jpg',
    '../../../../assets/img/poster/ucm_poster10.jpg',
  ];

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
