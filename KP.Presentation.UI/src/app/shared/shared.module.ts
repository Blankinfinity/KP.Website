import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorModalComponent } from './modals/error-modal/error-modal.component';
import { SuccessModalComponent } from './modals/success-modal/success-modal.component';
import { DatepickerDirective } from './directives/datepicker.directive';
import { LayoutComponent } from './components/layout/layout.component';
import { HeaderComponent } from './components/header/header.component';
import { MaterialModule } from '../core/material.module';
import { SidenavListComponent } from './components/navigation/sidenav-list/sidenav-list.component';

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
    HeaderComponent,
    SidenavListComponent
  ],
  exports: [
    ErrorModalComponent,
    SuccessModalComponent,
    DatepickerDirective,
    LayoutComponent,
    HeaderComponent,
    SidenavListComponent
  ]
})
export class SharedModule { }
