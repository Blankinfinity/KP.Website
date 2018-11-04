import { Component, OnInit } from '@angular/core';
import { SiteDownloadsService } from '../shared/sitedownloads.service';

@Component({
  selector: 'app-sitedownloads',
  templateUrl: './sitedownloads.component.html',
  styleUrls: ['./sitedownloads.component.scss']
})
export class SitedownloadsComponent implements OnInit {

  public sitedownloads: Array<any>;
  public sitedownloadsAsync: Array<any>;
  public currentSite: any;

  constructor(private siteDownloadsService: SiteDownloadsService) {
    siteDownloadsService.get().subscribe((data: any) => this.sitedownloads = data);
  }

  async ngOnInit() {
    this.sitedownloadsAsync = await this.siteDownloadsService.getasync();
  }

}
