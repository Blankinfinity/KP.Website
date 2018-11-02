import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SitedownloadsComponent } from './table/sitedownloads.component';

const routes: Routes = [{ path: 'sitedownloads',
component: SitedownloadsComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SitedownloadsRoutingModule { }
