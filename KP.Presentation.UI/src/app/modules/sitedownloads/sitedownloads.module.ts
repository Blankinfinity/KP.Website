import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SitedownloadsRoutingModule } from './sitedownloads-routing.module';
import { SitedownloadsComponent } from './table/sitedownloads.component';


@NgModule({
  imports: [
    CommonModule,
    SitedownloadsRoutingModule
  ],
  declarations: [SitedownloadsComponent]
})
export class SitedownloadsModule { }
