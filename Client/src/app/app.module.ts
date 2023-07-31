import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UiModule } from './ui/ui.module';
import { AuthUiModule } from './auth-ui/auth-ui.module';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule } from '@angular/router';
import { UserPanelModule } from './user-panel/user-panel.module';
import { AdminModule } from './admin/admin.module';
import { NgxSpinnerModule } from 'ngx-spinner';
import { CustomHttpErrorHandlerIntercepterService } from './services/common/custom-http-error-handler-intercepter.service';
import { JwtModule } from '@auth0/angular-jwt';
import { FranchisingFormModule } from './franchising-form/franchising-form.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    UiModule,
    AuthUiModule,
    FranchisingFormModule,
    UserPanelModule,
    AdminModule,
    ToastrModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem('token'),
        allowedDomains: [
          'https://localhost:7132',
          'https://api.omega-gym.com/api',
        ],
      },
    }),
    NgxSpinnerModule,
  ],
  providers: [
    // json-server
    {
      provide: 'baseUrl',
      useValue: 'https://api.omega-gym.com/api',
      multi: true,
    },
    {
      provide: 'baseUrl2',
      useValue: 'https://localhost:7132/api',
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CustomHttpErrorHandlerIntercepterService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
