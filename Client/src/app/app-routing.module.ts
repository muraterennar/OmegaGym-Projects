import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UiComponent } from './ui/ui.component';
import { RegisterComponent } from './auth-ui/register/register.component';
import { LoginComponent } from './auth-ui/login/login.component';
import { UserPanelLayoutComponent } from './user-panel/user-panel-layout/user-panel-layout.component';
import { DashboardComponent } from './user-panel/user-panel-components/dashboard/dashboard.component';
import { SubscriptionComponent } from './user-panel/user-panel-components/subscription/subscription.component';
import { MyProgramsComponent } from './user-panel/user-panel-components/my-programs/my-programs.component';
import { UserSettingsComponent } from './user-panel/user-panel-components/user-settings/user-settings.component';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { AdminDashboardComponent } from './admin/admin-components/admin-dashboard/admin-dashboard.component';
import { AdminSubscriptionComponent } from './admin/admin-components/admin-subscription/admin-subscription.component';
import { AuthGuard } from './guards/common/auth.guard';
import { AdminPanelGuard } from './guards/admin-panel.guard';
import { ResetPasswordComponent } from './auth-ui/reset-password/reset-password.component';
import { UpdatePasswordComponent } from './auth-ui/update-password/update-password.component';
import { FranchisingFormComponent } from './franchising-form/franchising-form.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: UiComponent,
  },
  {
    path: 'anasayfa',
    component: UiComponent,
  },
  {
    path: 'uyelik',
    component: RegisterComponent,
  },
  {
    path: 'giris',
    component: LoginComponent,
  },
  {
    path: 'reset-password',
    component:ResetPasswordComponent
  },
  {
    path: 'update-password/:userId/:resetToken',
    component:UpdatePasswordComponent
  },

  {
    path: 'kullanici-paneli',
    component: UserPanelLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', component: DashboardComponent, canActivate: [AuthGuard] },
      {
        path: 'uyeliklerim',
        component: SubscriptionComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'programlarim',
        component: MyProgramsComponent,
        canActivate: [AuthGuard],
      },
      {
        path: 'ayarlar',
        component: UserSettingsComponent,
        canActivate: [AuthGuard],
      },
    ],
  },

  {
    path: 'admin',
    component: AdminLayoutComponent,
    canActivate: [AdminPanelGuard],
    children: [
      {
        path: '',
        component: AdminDashboardComponent,
        canActivate: [AdminPanelGuard],
      },
      {
        path: 'subscription',
        component: AdminSubscriptionComponent,
        canActivate: [AdminPanelGuard],
      },
    ],
  },

  {path:"franchising-basvurusu", component:FranchisingFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
