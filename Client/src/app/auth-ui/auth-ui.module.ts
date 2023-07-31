import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { UpdatePasswordComponent } from './update-password/update-password.component';

@NgModule({
  declarations: [LoginComponent, RegisterComponent, ResetPasswordComponent, UpdatePasswordComponent],
  imports: [CommonModule, RouterModule, ReactiveFormsModule],
  exports: [LoginComponent, RegisterComponent, ResetPasswordComponent],
})
export class AuthUiModule {}
