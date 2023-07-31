import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubscriptionModule } from './subscription/subscription.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { MyProgramsModule } from './my-programs/my-programs.module';
import { UserSettingsModule } from './user-settings/user-settings.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SubscriptionModule,
    DashboardModule,
    MyProgramsModule,
    UserSettingsModule,
  ],
  exports: [
    SubscriptionModule,
    DashboardModule,
    MyProgramsModule,
    UserSettingsModule,
  ],
})
export class UserPnaleComponentsModule {}
