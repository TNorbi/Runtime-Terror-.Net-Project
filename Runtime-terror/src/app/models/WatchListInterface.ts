export interface WatchListInterface {
  code: number;
  message: string;
  watchlist: WatchList | null;
}

export interface WatchListForAllMoviesInterface {
  code: number;
  message: string;
  watchlist: WatchList | null;
}

export interface WatchList {
  username: string;
  movies: WatchlistMovieData[] | null;
}

export interface WatchlistMovieData {
  id: number;
  title: string;
}
