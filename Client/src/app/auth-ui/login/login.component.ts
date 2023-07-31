import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthLoginModel } from 'src/app/models/authLoginModel';
import { AuthTokenModel } from 'src/app/models/common/AuthTokenModel';
import { AuthService } from 'src/app/services/common/auth.service';
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
import { Modal, ModalInterface, ModalOptions } from 'flowbite';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  submitted: boolean = false;

  second: number = 119;
  countdown: string = '02 : 00';

  status: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private customToastrService: CustomToastrService,
    private customSpinnerService: CustomSpinnerService,
    private customLocalStorageService: CustomLocalStorageService,
    private router: Router,
    private toastr: CustomToastrService
  ) {}

  // Reactive Form
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: [
        '',
        [
          Validators.required,
          Validators.email,
          Validators.minLength(13),
          Validators.maxLength(150),
        ],
      ],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(12),
          // this.passwordValidator,
        ],
      ],
    });
  }

  // Password Validaiton İşlemi (Özel Krakter / Büyük Küçük Harf / Rakam)
  passwordValidator(control: FormControl): { [key: string]: boolean } | null {
    const password = control.value;
    const hasUpperCase = /[A-Z]/.test(password);
    const hasLowerCase = /[a-z]/.test(password);
    const hasNumbers = /\d/.test(password);
    const hasSpecialCharacters = /[!@#$%^&*(),.?":{}|<>]/.test(password);

    const valid =
      hasUpperCase && hasLowerCase && hasNumbers && hasSpecialCharacters;
    if (!valid) {
      return { invalidPassword: true };
    }

    return null;
  }

  get loginComponent() {
    return this.loginForm.controls;
  }

  // ====================== Submit Form / Login Operation ======================
  onSubmit(data: Partial<AuthLoginModel>) {
    this.customSpinnerService.showSpinner(CustomSpinnerName.spinner_one);
    this.submitted = true;

    if (this.loginForm.invalid)
      this.customSpinnerService.hideSpinner(CustomSpinnerName.spinner_one);

    // async login
    this.authService.loginAsync(
      data,
      (response: { token: string; expirationDate: string }) => {
        // Düzgün Çalıştığında
        this.customSpinnerService.hideSpinner(CustomSpinnerName.spinner_one);

        this.customLocalStorageService.addStorage('token', response.token);

        this.showModel('modalEl', true, () => {
          this.countdownOperation();
          this.authService.sendSingleCodeToMail(
            data.email,
            () => {
              this.toastr.alertMessage({
                title: '√',
                message: 'Mail Başarıyla Gönderildi',
                messageType: ToastrMessageType.Success,
                position: ToastrPosition.TopRight,
              });
            },
            () => {
              window.location.reload();
              this.toastr.alertMessage({
                title: 'Başarısız',
                message: 'Lütfen Tekrar Deneyin',
                messageType: ToastrMessageType.Info,
                position: ToastrPosition.TopRight,
              });
            }
          );
        });
      },
      (errorResponse: any) => {
        // Hata Alındığında
        this.customSpinnerService.hideSpinner(CustomSpinnerName.spinner_one);
        window.location.reload;
        console.log(errorResponse);
        this.customToastrService.alertMessage({
          title: 'Hata !',
          message: 'Tekrar Deneyin',
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopRight,
        });
      }
    );
  }

  onTwoFactor(data: Partial<AuthLoginModel>, singleCode: HTMLInputElement) {
    this.customSpinnerService.showSpinner(CustomSpinnerName.spinner_one);
    this.submitted = true;

    if (singleCode.value || singleCode.value.length == 6) {
      this.status = true;
      this.customSpinnerService.hideSpinner(CustomSpinnerName.spinner_one);

      this.authService.twoFactorAuth(
        data.email,
        singleCode.value,
        (response?: { message: string; status: boolean }) => {
          this.showModel('modalEl', false);

          if (response.status == false) {
            this.customLocalStorageService.clearStorage();
            this.router.navigate(['/giris']).then(() => {
              window.location.reload();
            });
          } else {
            this.router.navigate(['']).then(() => {
              window.location.reload();
            });
          }
        },
        (errorResponse?: HttpErrorResponse | any) => {
          this.customLocalStorageService.clearStorage();
          this.showModel('modalEl', false);
          this.router.navigate(['/giris']).then(() => {
            window.location.reload();
          });
          this.toastr.alertMessage({
            title: 'Doğrulama Hatası',
            message: 'Girdiğiniz Kod Yanlış',
            messageType: ToastrMessageType.Info,
            position: ToastrPosition.TopRight,
          });
        }
      );
    }

    this.customSpinnerService.hideSpinner(CustomSpinnerName.spinner_one);
  }

  // ====================== Submit Form / Login Operation ======================

  // Password Open/Hide Operation
  toogleEye(
    eyeOpen: HTMLElement,
    eyeClose: HTMLElement,
    passwordInput: HTMLInputElement
  ) {
    let ifOpenEye = eyeOpen.classList.contains('hidden');

    if (!ifOpenEye) {
      eyeOpen.classList.add('hidden');
      eyeClose.classList.remove('hidden');
      passwordInput.type = 'text';
    } else {
      eyeOpen.classList.remove('hidden');
      eyeClose.classList.add('hidden');
      passwordInput.type = 'password';
    }
  }

  // Countdown - Geri Sayım
  countdownOperation() {
    const interval = setInterval(() => {
      const dakika = Math.floor(this.second / 60);
      const saniyeKalan = this.second % 60;

      this.countdown = `0${dakika} : ${
        saniyeKalan.toString().length == 2 ? '' : '0'
      }${saniyeKalan}`;
      this.second--;

      if (this.second < 0) {
        this.countdown = '00 : 00';
        clearInterval(interval);
        window.location.reload();
      }
    }, 1000);
  }

  showModel(id: string, status: boolean = true, callBackFunction?: () => void) {
    const $targetEl = document.getElementById(id);
    const options: ModalOptions = {
      placement: 'center',
      backdrop: 'static',
      backdropClasses: `bg-gray-900 bg-opacity-50 dark:bg-opacity-80 fixed inset-0 z-40`,
      closable: false,
      onHide: () => {
        window.location.reload;
      },
      onShow: () => {
        callBackFunction();
      },
      onToggle: () => {
        console.log('modal has been toggled');
      },
    };
    const modal = new Modal($targetEl, options);

    if (status) {
      modal.show();
    } else {
      modal.hide();
    }
  }
}
