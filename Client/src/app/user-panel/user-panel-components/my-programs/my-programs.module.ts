import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyProgramsComponent } from './my-programs.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [MyProgramsComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([{ path: '', component: MyProgramsComponent }]),
  ],
  exports: [MyProgramsComponent],
})
export class MyProgramsModule {}
