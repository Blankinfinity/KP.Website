import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SitedownloadsComponent } from './sitedownloads.component';

describe('SitedownloadsComponent', () => {
  let component: SitedownloadsComponent;
  let fixture: ComponentFixture<SitedownloadsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SitedownloadsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SitedownloadsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
