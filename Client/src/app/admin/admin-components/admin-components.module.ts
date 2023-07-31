import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminDashboardModule } from './admin-dashboard/admin-dashboard.module';
import { AdminSubscriptionModule } from './admin-subscription/admin-subscription.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    AdminDashboardModule,
    AdminSubscriptionModule
  ],
  exports:[
    AdminDashboardModule,
    AdminSubscriptionModule
  ]
})
export class AdminComponentsModule { }
