import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminSubscriptionComponent } from './admin-subscription.component';



@NgModule({
  declarations: [
    AdminSubscriptionComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    AdminSubscriptionComponent
  ]
})
export class AdminSubscriptionModule { }
