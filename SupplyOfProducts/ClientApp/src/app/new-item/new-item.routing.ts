import { Routes, RouterModule } from '@angular/router';
import { MediaItemFormComponent } from './media-item-form.component';
import { WorkerFormComponent } from './worker-form.component';

const newItemRoutes: Routes = [
  { path: '', component: MediaItemFormComponent },
  { path: 'work', component: WorkerFormComponent },
  { path: 'work/:code', component: WorkerFormComponent },
];

export const newItemRouting = RouterModule.forChild(newItemRoutes);
 
