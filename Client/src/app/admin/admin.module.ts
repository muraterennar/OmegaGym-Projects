import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminLayoutModule } from './admin-layout/admin-layout.module';
import { AdminComponentsModule } from './admin-components/admin-components.module';

@NgModule({
  declarations: [],
  imports: [CommonModule, AdminLayoutModule, AdminComponentsModule],
  exports: [AdminLayoutModule, AdminComponentsModule],
})
export class AdminModule {}
