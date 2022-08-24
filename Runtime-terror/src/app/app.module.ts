import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { MovieComponent } from './components/movie/movie.component';
import { MovieDetailsComponent } from './components/movie-details/movie-details.component';
import { TvShowComponent } from './components/tv-show/tv-show.component';
import { PricingComponent } from './components/pricing/pricing.component';
import { BlogComponent } from './components/blog/blog.component';
import { BlogDetailsComponent } from './components/blog-details/blog-details.component';
import { ContactComponent } from './components/contact/contact.component';
import { HomeVariantComponent } from './components/home-variant/home-variant.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginComponent } from './components/login/login.component';
import { CardComponent } from './components/card/card.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component';
import { UpcomingMoviesComponent } from './components/home/upcoming-movies/upcoming-movies.component';
import { TopRatedMoviesComponent } from './components/home/top-rated-movies/top-rated-movies.component';
import { GlobalConstants } from './common/global-constants';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MovieComponent,
    MovieDetailsComponent,
    TvShowComponent,
    PricingComponent,
    BlogComponent,
    BlogDetailsComponent,
    ContactComponent,
    HomeVariantComponent,
    LoginComponent,
    CardComponent,
    HeaderComponent,
    UpcomingMoviesComponent,
    TopRatedMoviesComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    NoopAnimationsModule,
  ],
  providers: [GlobalConstants],
  bootstrap: [AppComponent],
})
export class AppModule {}
