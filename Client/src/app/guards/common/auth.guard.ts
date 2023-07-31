import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { CustomLocalStorageService } from 'src/app/services/common/custom-local-storage.service';
import {
  CustomSpinnerName,
  CustomSpinnerService,
} from 'src/app/services/common/custom-spinner.service';
import {
  CustomToastrService,
  ToastrMessageType,
  ToastrPosition,
} from 'src/app/services/common/custom-toastr.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private jwtHelperService: JwtHelperService,
    private toastrService: CustomToastrService,
    private router: Router,
    private spinnerService: CustomSpinnerService,
    private storageService: CustomLocalStorageService
  ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    this.spinnerService.showSpinner(CustomSpinnerName.spinner_one);
    const token: string = localStorage.getItem('token');

    const decodedToken = this.jwtHelperService.decodeToken(token);
    let expiration: boolean;

    try {
      expiration = this.jwtHelperService.isTokenExpired(token);
    } catch {
      expiration = true;
    }

    if (!token || expiration) {
      this.router.navigate(['giris'], {
        queryParams: { returnValue: state.url },
      });

      this.storageService.clearStorage();

      this.toastrService.alertMessage({
        title: 'Giriş Yap',
        message: 'Bu işlem için giriş yapmalısınız',
        messageType: ToastrMessageType.Info,
        position: ToastrPosition.TopRight,
      });
    }

    this.spinnerService.hideSpinner(CustomSpinnerName.spinner_one);
    return true;
  }
}

export enum ClaimType {
  role = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role',
  exp = 'exp',
  firstName = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname',
  lastName = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname',
  username = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name',
  gender = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/gender',
  id = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier',
}
