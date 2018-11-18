import { TestBed } from '@angular/core/testing';

import { CodeMazeService } from './code-maze.service';

describe('CodeMazeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CodeMazeService = TestBed.get(CodeMazeService);
    expect(service).toBeTruthy();
  });
});
