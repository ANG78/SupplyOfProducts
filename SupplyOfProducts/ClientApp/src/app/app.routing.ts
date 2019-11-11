import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { WorkerListComponent } from './worker-list.component';
import { WorkPlaceListComponent } from './workPlace-list.component';
import { ProductListComponent } from './product-list.component';
import { WorkerComponent } from './worker.component';
import { WorkPlaceComponent } from './workPlace.component';
    
const appRoutes: Routes = [

  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'workers', component: WorkerListComponent },
  { path: 'workplaces', component: WorkPlaceListComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'workers/worker/:code', component: WorkerComponent },
  { path: 'workplaces/workplace/:code', component: WorkPlaceComponent },
  { 
    path: 'add',
    loadChildren: () => import('./new-item/new-item.module').then(m => m.NewItemModule)
  },
];           
       
// 

export const routing = RouterModule.forRoot(appRoutes);

/*
 
  { path: ':medium', component: MediaItemListComponent },
 */
