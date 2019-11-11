import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WorkerService, Worker } from './worker.service';

@Component({
  selector: 'worker-list',
  templateUrl: './worker-list.component.html',
  styleUrls: ['./list.component.css']
})
export class WorkerListComponent implements OnInit {
  workers: Worker[];

  constructor(
    private workerService: WorkerService,
    private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    this.activatedRoute.paramMap
      .subscribe(paramMap => {
        this.getWorkers();
      });
  }

  onDelete(worker: Worker) {
    this.workerService.delete(worker)
      .subscribe(() => {
        this.getWorkers();
      });
  }

  getWorkers() {
    this.workerService.get('')
      .subscribe(items => {
          this.workers = items;
      });
  }

}
