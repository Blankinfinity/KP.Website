import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorModalComponent } from './modals/error-modal/error-modal.component';
import { SuccessModalComponent } from './modals/success-modal/success-modal.component';
import { DatepickerDirective } from './directives/datepicker.directive';
import { LayoutComponent } from './components/layout/layout.component';
import { HeaderComponent } from './components/header/header.component';
import { MaterialModule } from '../core/material.module';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule
  ],
  declarations: [
    ErrorModalComponent,
    SuccessModalComponent,
    DatepickerDirective,
    LayoutComponent,
    HeaderComponent
  ],
  exports: [
    ErrorModalComponent,
    SuccessModalComponent,
    DatepickerDirective,
    LayoutComponent,
    HeaderComponent
  ]
})
export class SharedModule { }
