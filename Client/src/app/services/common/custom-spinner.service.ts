import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root',
})
export class CustomSpinnerService {
  constructor(private customSpinner: NgxSpinnerService) {}

  hideSpinner(name: CustomSpinnerName | string) {
    this.customSpinner.hide(name);
  }

  showSpinner(name: CustomSpinnerName | string) {
    this.customSpinner.show(name);
  }
}

export enum CustomSpinnerName {
  spinner_one = 'OmegaGymSpinner',
  Page404 = 'OmegaGym404Page',
  Page500 = 'OmegaGym500Page',
  PageUnknown = "OmegaGymUnknownPage"
}
