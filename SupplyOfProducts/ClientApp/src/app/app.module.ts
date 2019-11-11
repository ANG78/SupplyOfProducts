import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { routing } from './app.routing';
import { lookupListToken, lookupLists } from './providers';
import { MockXHRBackend } from './mock-xhr-backend';
import { MediaItemComponent } from './media-item.component';
import { MediaItemListComponent } from './media-item-list.component';
import { ProductListComponent } from './product-list.component';
import { CategoryListComponent } from './category-list.component';
import { WorkerComponent } from './worker.component';
import { WorkerListComponent } from './worker-list.component';
import { WorkPlaceComponent } from './workPlace.component';
import { WorkPlaceListComponent } from './workPlace-list.component';
import { FavoriteDirective } from './favorite.directive';
import { CategoryListPipe } from './category-list.pipe';
 
   
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    MediaItemComponent,
    MediaItemListComponent,
    ProductListComponent,
    CategoryListComponent,
    WorkerComponent,
    WorkerListComponent,
    WorkPlaceComponent,
    WorkPlaceListComponent,
    FavoriteDirective,
    CategoryListPipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    routing,
  ],
  providers: [
    { provide: lookupListToken, useValue: lookupLists },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


/*
 * { provide: HttpXhrBackend, useClass: MockXHRBackend }
 */
