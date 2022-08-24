import { ThisReceiver } from '@angular/compiler';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { GlobalConstants } from 'src/app/common/global-constants';
import { MovieInterface } from 'src/app/models/MovieInterface';
import {
  WatchListForAllMoviesInterface,
  WatchListInterface,
  WatchlistMovieData,
} from 'src/app/models/WatchListInterface';
import { MovieService } from 'src/app/services/movie.service';
import { WatchListService } from 'src/app/services/watchlist.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.scss'],
})
export class MovieDetailsComponent implements OnInit, OnChanges {
  _movieNr!: string;
  _movieData!: MovieInterface;
  movieNumber!: number;
  zeroNeeded = '0';
  _movieAdded!: boolean;
  _buttonName: string = 'Add to watchlist';
  _watchListData!: WatchListForAllMoviesInterface;

  get buttonName(): string {
    return this._buttonName;
  }
  @Input() set buttonName(value: string) {
    if (value !== this._buttonName) {
      this._buttonName = value;
    }
  }

  get watchListData(): WatchListForAllMoviesInterface {
    return this._watchListData;
  }
  set watchListData(value: WatchListForAllMoviesInterface) {
    if (value !== this._watchListData) {
      this._watchListData = value;
    }
  }

  get movieAdded(): boolean {
    return this._movieAdded;
  }

  @Input() set movieAdded(value: boolean) {
    this._movieAdded = value;
  }

  set movieNr(value: string) {
    this._movieNr = value;
  }

  get movieNr(): string {
    return this._movieNr;
  }
  set movieData(value: MovieInterface) {
    this._movieData = value;
    //console.log(value);
    if (value.code === 200) {
      //this._moviesData.emit();
      //console.log('Movies have arrived successfully');
    }
  }

  get movieData(): MovieInterface {
    return this._movieData;
  }

  constructor(
    private route: ActivatedRoute,
    private movieService: MovieService,
    public globalConstants: GlobalConstants,
    private watchlistService: WatchListService
  ) {}
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['globalConstants'].currentValue) {
      this.getWatchlist();
      console.log('INIT watchlist');
    }
    if (changes['movieAdded'].currentValue === true) {
      this.buttonName = 'Remove from watchlist';
    } else {
      this.buttonName = 'Add to watchlist';
    }
  }

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.movieNr = params['movieNr'];
    });
    setTimeout(() => {
      // <<<---using ()=> syntax
      this.movieNumber = Number(this.movieNr) + 1;
      if (this.movieNumber > 9) {
        this.zeroNeeded = '';
      }
      if (this.movieNumber) {
        this.movieService.getMovie(this.movieNumber).subscribe((data) => {
          this.movieData = data;
          //console.log('MOVIE: ' + this.movieData);
        });
      }
    }, 500);
  }

  getWatchlist() {
    if (this.globalConstants.userID == undefined) {
      console.log('Unidentified user id');
    } else {
      this.watchlistService
        .getUserWatchlistById(this.globalConstants.userID)
        .subscribe((data) => {
          //console.log(data);
          this.watchListData = data;
          if (this.watchListData.watchlist !== null) {
            if (this.watchListData.watchlist.movies !== null) {
              for (let movie of this.watchListData.watchlist.movies) {
                if (movie.id.toString() == this.movieNr) {
                  this.movieAdded = true;
                  console.log(
                    'Movie id:' + movie.id + ' MovieNr: ' + this.movieNr
                  );
                }
              }
            }
          }
        });
    }
  }

  removeWatchlistMovie() {
    if (this.globalConstants.userID && this.movieData.movie) {
      console.log(
        'Ez meg kell eggyezzen az elso szammal: ' + this.movieData.movie.mov_Id
      );
      this.watchlistService
        .removeFromWatchlist(
          this.globalConstants.userID,
          this.movieData.movie.mov_Id
        )
        .subscribe();
      //console.log('AZ ADDBE SIKERULT BELEPNI');
      this.movieAdded = true;
      this.buttonName = 'Add to watchlist';
      console.log(this.movieData.movie.mov_Id + ' id-ju FILM torolve');
    }
  }

  addWatchlistMovie() {
    if (this.globalConstants.userID && this.movieData.movie) {
      this.watchlistService
        .addToWatchlist(
          this.globalConstants.userID,
          this.movieData.movie.mov_Id
        )
        .subscribe();
      this.movieAdded = false;
      this.buttonName = 'Remove from watchlist';

      console.log(this.movieData.movie.mov_Id + ' id-ju FILM hozzaadva');
    }
  }
}

/*else {
        if (this.globalConstants.userID && this.movieData.movie) {
          this.watchlistService
            .removeFromWatchlist(
              this.globalConstants.userID,
              this.movieData.movie.mov_Id
            )
            .subscribe();
        }
        console.log('AZ REMOVEBA SIKERULT BELEPNI');
        this.movieAdded = false;
        this.buttonName = 'Add to watchlist';
      }

*/
