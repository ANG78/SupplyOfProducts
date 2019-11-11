import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WorkPlaceService } from './workplace.service';

@Component({
  selector: 'workplace-item',
  templateUrl: './workPlace.component.html',
  styleUrls: ['./worker.component.css']
})
export class WorkPlaceComponent implements OnInit {
  @Input() item;
  @Output() delete = new EventEmitter();

  constructor(private routes: ActivatedRoute, private service: WorkPlaceService) { }

  ngOnInit(): void {
    this.routes.params.subscribe(parameters => {
      const code = parameters['code'];


      this.service.get(code).subscribe(items => {
        this.item = items[0];
      });
    });
  }

  onDelete() {
    this.delete.emit(this.item);
  }
}
