import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FranchisingFormComponent } from './franchising-form.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [FranchisingFormComponent],
  imports: [CommonModule, RouterModule, ReactiveFormsModule],
  exports: [FranchisingFormComponent],
})
export class FranchisingFormModule {}
