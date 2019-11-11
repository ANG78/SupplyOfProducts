import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { WorkerService } from '../worker.service';

@Component({
  selector: 'worker-form',
  templateUrl: './worker-form.component.html',
  styleUrls: ['./worker-form.component.css']
})
export class WorkerFormComponent implements OnInit {
  form: FormGroup;
  work: any = {id: 0, code:'', name: ''}

  constructor(
    private formBuilder: FormBuilder,
    private workerService: WorkerService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {
    this.route.params.subscribe({
      next: parameters => {
        const code = parameters['code'];

        if (code !== "") {
          this.work = this.workerService.get(code);
        }
        
      }
    });
    this.form = this.formBuilder.group({
      code: this.formBuilder.control('', Validators.compose([
        Validators.required,
        Validators.pattern('[\\w\\-\\s\\/]+')
      ])),
      name: this.formBuilder.control('', Validators.compose([
        Validators.required,
        Validators.pattern('[\\w\\-\\s\\/]+')
      ])),
    });
  }

  onSubmit(worker) {
      this.workerService.add(worker)
        .subscribe(() => {
          this.router.navigate(['/workers']);
        });
  }
}
