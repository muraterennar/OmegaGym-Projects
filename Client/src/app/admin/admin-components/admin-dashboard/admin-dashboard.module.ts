import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminDashboardComponent } from './admin-dashboard.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [AdminDashboardComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{ path: '', component: AdminDashboardComponent }]),
  ],
  exports: [AdminDashboardComponent],
})
export class AdminDashboardModule {}
