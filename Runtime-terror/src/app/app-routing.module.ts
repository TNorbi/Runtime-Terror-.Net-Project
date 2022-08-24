import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { HomeVariantComponent } from './components/home-variant/home-variant.component';
import { AppComponent } from './app.component';
import { MovieComponent } from './components/movie/movie.component';
import { TvShowComponent } from './components/tv-show/tv-show.component';
import { MovieDetailsComponent } from './components/movie-details/movie-details.component';
import { BlogComponent } from './components/blog/blog.component';
import { BlogDetailsComponent } from './components/blog-details/blog-details.component';
import { PricingComponent } from './components/pricing/pricing.component';
import { ContactComponent } from './components/contact/contact.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },

  { path: 'movie', component: MovieComponent },

  {
    path: 'home/movie-details',
    component: MovieDetailsComponent,
  },

  { path: 'tv-show', component: TvShowComponent },
  { path: 'blog', component: BlogComponent },
  {
    path: 'blog-details',
    component: BlogDetailsComponent,
  },
  { path: 'pricing', component: PricingComponent },
  { path: 'contact', component: ContactComponent },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  declarations: [],
  exports: [RouterModule],
})
export class AppRoutingModule {}
