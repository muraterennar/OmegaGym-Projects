import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SubscriptionModel } from 'src/app/models/subscriptionModel';
import { CustomToastrService } from 'src/app/services/common/custom-toastr.service';
import { SubscriptionService } from 'src/app/services/models/subscription.service';

@Component({
  selector: 'app-admin-subscription',
  templateUrl: './admin-subscription.component.html',
  styleUrls: ['./admin-subscription.component.css'],
})
export class AdminSubscriptionComponent implements OnInit {
  subscriptions: SubscriptionModel[];
finess: SubscriptionModel[];

  constructor(
    private subscriptionService: SubscriptionService,
    toastr: CustomToastrService
  ) {}

  ngOnInit(): void {
    this.subscGetAll();
  }

  subscGetAll() {
    this.subscriptionService.getAll().subscribe(
      (response) => {
        this.subscriptions = response;
      },
      (errorResponse: HttpErrorResponse) => {
        console.log(errorResponse);
      }
    );
  }

  subsFitnessCategory(){
    this.subscriptionService.getByDetails('fitness').subscribe((response)=>{

    })
  }
}
