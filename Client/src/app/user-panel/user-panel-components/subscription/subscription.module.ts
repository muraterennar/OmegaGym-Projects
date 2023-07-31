import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubscriptionComponent } from './subscription.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    SubscriptionComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: SubscriptionComponent }
    ])
  ],
  exports:[
    SubscriptionComponent
  ]
})
export class SubscriptionModule { }
