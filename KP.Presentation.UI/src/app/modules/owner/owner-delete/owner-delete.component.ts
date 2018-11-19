import { Component, OnInit } from '@angular/core';
import { CodeMazeService } from '../../../services/code-maze.service';
import { Owner } from '../../../shared/_interfaces/owner.model';
import { ErrorHandlerService } from '../../../core/services/error-handler.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-owner-delete',
  templateUrl: './owner-delete.component.html',
  styleUrls: ['./owner-delete.component.scss']
})
export class OwnerDeleteComponent implements OnInit {
  public errorMessage = '';
  public owner: Owner;

constructor(private codeMazeService: CodeMazeService, private errorHandler: ErrorHandlerService, private router: Router,
  private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.getOwnerById();
  }

  private getOwnerById() {
    const ownerId = this.activeRoute.snapshot.params['id'];
    const ownerByIdUrl = `api/owner/${ownerId}`;

    this.codeMazeService.getData(ownerByIdUrl)
      .subscribe(res => {
        this.owner = res as Owner;
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
  }

  public redirectToOwnerList() {
    this.router.navigate(['/owner/list']);
  }

  public deleteOwner() {
    const deleteUrl = `api/owner/${this.owner.id}`;
    this.codeMazeService.delete(deleteUrl)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      });
  }
}
