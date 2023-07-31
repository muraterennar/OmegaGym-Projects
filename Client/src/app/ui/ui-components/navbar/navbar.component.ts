import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ClaimType } from 'src/app/guards/common/auth.guard';
import { CustomLocalStorageService } from 'src/app/services/common/custom-local-storage.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  constructor(
    private jwtHelper: JwtHelperService,
    private router: Router,
    private customLocalStorage: CustomLocalStorageService
  ) {}

  token: string = localStorage.getItem('token');
  decodeToken = this.jwtHelper.decodeToken(this.token);
  expireDate: boolean = this.jwtHelper.isTokenExpired(this.token);

  firstName: string = '';
  lastName: string = '';
  gender?: string = 'erkek';
  ngOnInit(): void {
    this.tokenControl();
  }

  closeButton(mobilNavbar: HTMLElement, navbar: HTMLElement) {
    if (navbar.offsetWidth == 320 || navbar.offsetWidth <= 428) {
      mobilNavbar.style.transform = `translateX(${-30}rem)`;
    }
    // 320 / 430
  }

  tokenControl() {
    if (this.decodeToken) {
      this.firstName = this.decodeToken[ClaimType.firstName];
      this.lastName = this.decodeToken[ClaimType.lastName];
      this.gender = this.decodeToken[ClaimType.gender];
    } else {
      return;
    }
  }

  avatarControl(): boolean {
    this.tokenControl();
    if (this.decodeToken && !this.expireDate) {
      return true;
    }
    return false;
  }

  adminRoleControle() {
    this.tokenControl();
    if (
      this.decodeToken &&
      !this.expireDate &&
      this.decodeToken[ClaimType.role] == 'admin'
    ) {
      return true;
    }
    return false;
  }

  openHamburger(
    closeBtn: HTMLElement,
    mabilNavbar: HTMLElement,
    hamburgerBtn: HTMLElement
  ) {
    window.event.preventDefault();
    mabilNavbar.style.transform = `translateX(${0})`;
    closeBtn.style.color = '#fff';
    hamburgerBtn.classList.add('.hidden');
    closeBtn.classList.add('.max-ms:block');
  }

  singOut() {
    this.router.navigate(['']).then(() => {
      this.customLocalStorage.clearStorage();
      location.reload();
    });
  }

  adminToUser() {
    switch (this.decodeToken[ClaimType.role]) {
      case 'admin':
        this.router.navigate(['/admin']);
        break;
      case 'user':
        this.router.navigate(['/kullanici-paneli']);
        break;
      default:
        this.router.navigate(['']);
        break;
    }
  }
}
