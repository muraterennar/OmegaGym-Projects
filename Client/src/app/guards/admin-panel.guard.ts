import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import {
  CustomToastrService,
  ToastrMessageType,
  ToastrPosition,
} from '../services/common/custom-toastr.service';
import { CustomLocalStorageService } from '../services/common/custom-local-storage.service';
import { ClaimType } from './common/auth.guard';

@Injectable({
  providedIn: 'root',
})
export class AdminPanelGuard implements CanActivate {
  constructor(
    private jwtHelperService: JwtHelperService,
    private toastrService: CustomToastrService,
    private router: Router,
    private storageService: CustomLocalStorageService
  ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const token: string = localStorage.getItem('token');

    const decodedToken = this.jwtHelperService.decodeToken(token);
    let role: string = '';
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

    if (token || !expiration) {
      role = decodedToken[ClaimType.role];
      if (role == 'admin') {
        return true;
      } else {
        this.router.navigate(['giris'], {
          queryParams: { returnValue: state.url },
        });

        this.toastrService.alertMessage({
          title: 'Giriş Yap',
          message: 'Bu işlem için giriş yapmalısınız',
          messageType: ToastrMessageType.Info,
          position: ToastrPosition.TopRight,
        });
      }
    }

    return true;
  }
}
