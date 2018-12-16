import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SiteDownloads } from './sitedownloads.model';
import { EnvironmentUrlService } from 'src/app/core/services/environment-url.service';

@Injectable({
  providedIn: 'root',
})
export class SiteDownloadsService {

  private headers: HttpHeaders;
  private accessPointUrl = 'https://localhost:44373/api/sitedownloads';

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
   }

   public get() {
    // Get all sitedownload data
    return this.http.get(this.envUrl.urlAddress, {headers: this.headers});
  }

  // Async test
  public async getasync(): Promise<SiteDownloads[]> {
    // Get all sitedownload data async
    const response = await this.http.get(this.envUrl.urlAddress, {headers: this.headers}).toPromise();
    return response as SiteDownloads[];
  }

  public add(payload) {
    return this.http.post(this.envUrl.urlAddress, payload, {headers: this.headers});
  }

  public remove(payload) {
    return this.http.delete(this.envUrl.urlAddress + '/' + payload.id, {headers: this.headers});
  }

  public update(payload) {
    return this.http.put(this.envUrl.urlAddress + '/' + payload.id, payload, {headers: this.headers});
  }
}
