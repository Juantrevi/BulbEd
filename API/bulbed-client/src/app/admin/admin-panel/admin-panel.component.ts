import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import {InstitutionService} from "../../_services/institution.service";
import {catchError, of, tap} from "rxjs";


@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {
  createInstitutionForm: FormGroup | any;

  constructor(
    private formBuilder: FormBuilder,
    private institutionService: InstitutionService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.createInstitutionForm = this.formBuilder.group({
      name: ['', Validators.required],
      // Other form controls...
    });
  }


onSubmit() {
  this.institutionService.createInstitution(this.createInstitutionForm.value)
    .pipe(
      tap((response: any) => {
        this.toastr.success(response.message);
      }),
      catchError(error => {
        this.toastr.error('There was an error creating the institution');
        console.log(error);
        return of(error);
      })
    )
    .subscribe();
}
}
