import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './footer/footer.component';
import { NgxTypedJsModule } from 'ngx-typed-js';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [NavbarComponent, MainComponent, FooterComponent],
  imports: [CommonModule, NgxTypedJsModule, RouterModule],
  exports: [NavbarComponent, MainComponent, FooterComponent],
})
export class UiComponentsModule {}
