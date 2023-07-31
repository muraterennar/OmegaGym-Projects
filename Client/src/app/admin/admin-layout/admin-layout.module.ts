import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminLayoutComponent } from './admin-layout.component';
import { AdminLayoutComponentsModule } from './admin-layout-components/admin-layout-components.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    AdminLayoutComponent
  ],
  imports: [
    CommonModule,AdminLayoutComponentsModule,RouterModule
  ],
  exports:[
    AdminLayoutComponent, AdminLayoutComponentsModule
  ]
})
export class AdminLayoutModule { }
