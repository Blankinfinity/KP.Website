import { Component, OnInit, Input } from '@angular/core';

// TODO: Revisit as Input from owner-details does not seem to be working. Data is in model but no output.
@Component({
  selector: 'app-owners-accounts',
  templateUrl: './owners-accounts.component.html',
  styleUrls: ['./owners-accounts.component.scss']
})
export class OwnersAccountsComponent implements OnInit {
    constructor() { }

    @Input() public accounts: Account[] = [];

    ngOnInit() {
  }
}
