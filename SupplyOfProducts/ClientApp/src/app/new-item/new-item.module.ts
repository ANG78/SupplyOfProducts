import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MediaItemFormComponent } from './media-item-form.component';
import { WorkerFormComponent } from './worker-form.component';
import { newItemRouting } from './new-item.routing';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    newItemRouting
  ],
  declarations: [
    MediaItemFormComponent,
    WorkerFormComponent
  ]
})
export class NewItemModule {}
