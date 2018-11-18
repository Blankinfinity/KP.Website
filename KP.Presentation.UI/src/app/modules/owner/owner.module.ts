import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OwnerListComponent } from './owner-list/owner-list.component';
import { RouterModule } from '@angular/router';
import { OwnerDetailsComponent } from './owner-details/owner-details.component';
import { SharedModule } from '../../shared/shared.module';
import { OwnersAccountsComponent } from './owner-details/owners-accounts/owners-accounts.component';
import { OwnerCreateComponent } from './owner-create/owner-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { OwnerUpdateComponent } from './owner-update/owner-update.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'list', component: OwnerListComponent },
      { path: 'details/:id', component: OwnerDetailsComponent },
      { path: 'create', component: OwnerCreateComponent },
      { path: 'update/:id', component: OwnerUpdateComponent}
    ])
  ],
  declarations: [OwnerListComponent, OwnerDetailsComponent, OwnersAccountsComponent, OwnerCreateComponent, OwnerUpdateComponent]
})
export class OwnerModule { }
