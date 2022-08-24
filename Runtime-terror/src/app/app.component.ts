import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UsersService } from '../services/users.service';
import { UserInterface } from '../models/users/UsersInterface';
import { MovieService } from './services/movie.service';
import { MoviesInterface } from './models/MovieInterface';
import * as jQuery from 'jquery';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  ngOnInit(): void {}
}
