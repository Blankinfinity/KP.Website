import { Component, OnInit } from '@angular/core';

import {BlogService} from '../services/blog.service';
import {Post} from '../posts.interface';
import {DataSource} from '@angular/cdk/table';
import {Observable} from 'rxjs/Observable';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private blogService: BlogService) { }

  displayedColumns = ['date_posted', 'title', 'category', 'delete'];
  dataSource = new PostDataSource(this.blogService);

  ngOnInit() {
  }

}

export class PostDataSource extends DataSource<any> {
  constructor(private blogService: BlogService) {
    super();
  }

  connect(): Observable<Post[]> {
    return this.blogService.getData();
  }

  disconnect() {
  }
}
