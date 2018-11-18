import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Owner } from 'src/app/shared/_interfaces/owner.model';
import { CodeMazeService } from 'src/app/services/code-maze.service';
import { ErrorHandlerService } from 'src/app/core/services/error-handler.service';

@Component({
  selector: 'app-owner-details',
  templateUrl: './owner-details.component.html',
  styleUrls: ['./owner-details.component.scss']
})
export class OwnerDetailsComponent implements OnInit {
  public owner: Owner;
  public errorMessage = '';

  constructor(private codeMazeService: CodeMazeService, private router: Router,
              private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.getOwnerDetails();
  }

  getOwnerDetails() {
    const id = this.activeRoute.snapshot.params['id'];
    const apiUrl = `api/owner/${id}/account`;

    this.codeMazeService.getData(apiUrl)
    .subscribe(res => {
      this.owner = res as Owner;
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    });
  }
}
