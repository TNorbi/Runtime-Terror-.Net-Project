import { UserData } from './UserInterface';

export interface MoviesInterface {
  code: number;
  message: string;
  movieList: MovieData[] | null;
}

export interface MovieInterface {
  code: number;
  message: string;
  movie: MovieData | null;
}

export interface MovieData {
  mov_Id: number;
  title: string;
  releaseDate: string;
  runTime: number;
  rating: number;
  numberOfRatings: number;
  description: string | null;
  genres: GenreData[] | null;
  userRating: number | null;
  users: UserData | null;
}

export interface GenreData {
  id: number;
  genreName: string;
  movies: string | null;
}
