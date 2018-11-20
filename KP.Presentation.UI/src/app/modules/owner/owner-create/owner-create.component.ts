import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CodeMazeService } from 'src/app/services/code-maze.service';
import { ErrorHandlerService } from '../../../core/services/error-handler.service';
import { OwnerForCreation } from '../../../shared/_interfaces/owner-for-creation.model';

@Component({
  selector: 'app-owner-create',
  templateUrl: './owner-create.component.html',
  styleUrls: ['./owner-create.component.scss']
})
export class OwnerCreateComponent implements OnInit {
  public errorMessage = '';

  public ownerForm: FormGroup;

  constructor(private codeMazeService: CodeMazeService, private errorHandler: ErrorHandlerService, private router: Router) { }

  ngOnInit() {
    this.ownerForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      dateOfBirth: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });
  }

  public validateControl(controlName: string) {
    if (this.ownerForm.controls[controlName].invalid && this.ownerForm.controls[controlName].touched) {
      return true;
    }
    return false;
  }

  public hasError(controlName: string, errorName: string) {
    if (this.ownerForm.controls[controlName].hasError(errorName)) {
      return true;
    }
    return false;
  }

  public executeDatePicker(event) {
    this.ownerForm.patchValue({ 'dateOfBirth': event });
  }

  public createOwner(ownerFormValue) {
    if (this.ownerForm.valid) {
      this.executeOwnerCreation(ownerFormValue);
    }
  }

  private executeOwnerCreation(ownerFormValue) {
    const owner: OwnerForCreation = {
      name: ownerFormValue.name,
      dateOfBirth: ownerFormValue.dateOfBirth,
      address: ownerFormValue.address
    };

    const apiUrl = 'api/owner';
    this.codeMazeService.create(apiUrl, owner)
      .subscribe(res => {
        // $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    );
  }

  public redirectToOwnerList() {
    this.router.navigate(['/owner/list']);
  }
}
