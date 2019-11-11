import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { ActivatedRoute, Route } from '@angular/router';
import { WorkerService } from './worker.service';

@Component({
  selector: 'worker-item',
  templateUrl: './worker.component.html',
  styleUrls: ['./worker.component.css']
})
export class WorkerComponent implements OnInit {

  @Input() worker: any = { id: 0, code: '', name: '' }     
  @Output() delete = new EventEmitter();
  @Output() update = new EventEmitter();

  constructor(private routes: ActivatedRoute,
             // private navigator: Route,
              private service: WorkerService) { }

  ngOnInit(): void {
    this.routes.params.subscribe( parameters => {
      const code = parameters['code'];


      this.service.get(code).subscribe(items => {
        this.worker = items[0];
      });
    });
  }

  onDelete() {
    this.delete.emit(this.worker);
  }

  onUpdate() {
    //this.navigator.redirectTo(
    this.update.emit(this.worker);
  }
}
