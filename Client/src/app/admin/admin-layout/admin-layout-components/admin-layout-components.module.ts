import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminSidebarComponent } from './admin-sidebar/admin-sidebar.component';
import { AdminHeaderComponent } from './admin-header/admin-header.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [AdminSidebarComponent, AdminHeaderComponent],
  imports: [CommonModule, RouterModule],
  exports: [AdminSidebarComponent, AdminHeaderComponent],
})
export class AdminLayoutComponentsModule {}
