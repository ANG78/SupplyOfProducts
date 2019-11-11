import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WorkPlaceService, WorkPlace } from './workPlace.service';

@Component({
  selector: 'workplace-list',
  templateUrl: './workplace-list.component.html',
  styleUrls: ['./list.component.css']
})
export class WorkPlaceListComponent implements OnInit {
  workplaces: WorkPlace[];

  constructor(
    private workPlaceService: WorkPlaceService,
    private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    this.activatedRoute.paramMap
      .subscribe(paramMap => {
        this.getWorkPlaces();
      });
  }

  onDelete(workPlace: WorkPlace) {
    this.workPlaceService.delete(workPlace)
      .subscribe(() => {
        this.getWorkPlaces();
      });
  }

  onWatch(workPlace: WorkPlace) {
    this.workPlaceService.delete(workPlace)
      .subscribe(() => {
        this.getWorkPlaces();
      });
  }

  getWorkPlaces() {
    this.workPlaceService.get('')
      .subscribe(items => {
        this.workplaces = items;
      });
  }
}
