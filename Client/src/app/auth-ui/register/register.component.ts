import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthRegisterModel } from 'src/app/models/authRegisterModel';
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

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerFrom: FormGroup;
  submitted: boolean = false;

  woman: string = Genders.woman;
  men: string = Genders.men;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private toastrService: CustomToastrService,
    private spinnerService: CustomSpinnerService,
    private customLocalStorageService: CustomLocalStorageService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.registerFrom = this.formBuilder.group(
      {
        firstName: [
          '',
          [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(250),
          ],
        ],
        lastName: [
          '',
          [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(250),
          ],
        ],
        email: [
          '',
          [
            Validators.required,
            Validators.email,
            Validators.minLength(3),
            Validators.maxLength(250),
          ],
        ],
        gender: [
          '',
          [
            Validators.required,
            Validators.minLength(5),
            Validators.maxLength(5),
          ],
        ],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(12),
            this.passwordValidator,
          ],
        ],
        confirmPassword: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(12),
            this.passwordValidator,
          ],
        ],
      },
      { validators: this.matchPasswords }
    );
  }

  // Password Confirm Operation
  matchPasswords(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password').value;
    const confirmPassword = control.get('confirmPassword').value;

    if (password !== confirmPassword) {
      return { mismatch: true };
    }

    return null;
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

  // Register property
  get registerComponnent() {
    return this.registerFrom.controls;
  }

  //  ====================== POST Register Operation ======================
  register(data: Partial<AuthRegisterModel>) {
    this.spinnerService.showSpinner(CustomSpinnerName.spinner_one);
    this.submitted = true;
    if (this.registerFrom.invalid || this.registerFrom.hasError('mismatch'))
      this.spinnerService.hideSpinner(CustomSpinnerName.spinner_one);

    const username = this.username(data.firstName, data.lastName);

    this.authService.registerAync(
      {
        firstName: data.firstName,
        lastName: data.lastName,
        username: username,
        email: data.email,
        gender: data.gender,
        password: data.password,
      },
      (response?: AuthTokenModel) => {
        console.log(response);
        // Set token Local Storage
        this.customLocalStorageService.addStorage('token', response.token);
        // Route Home page
        this.router.navigate(['']);
        this.spinnerService.hideSpinner(CustomSpinnerName.spinner_one);
      },
      (errorResponse: HttpErrorResponse | any) => {
        this.spinnerService.hideSpinner(CustomSpinnerName.spinner_one);
        this.toastrService.alertMessage({
          title: `Hata ! -- ${errorResponse.status}`,
          message: 'Bilinmeyen Bir Hatayla Karşılaşıldı',
          position: ToastrPosition.TopRight,
          messageType: ToastrMessageType.Error,
        });
      }
    );

    // Register Operation
    // this.authService
    //   .register({
    //     firstName: data.firstName,
    //     lastName: data.lastName,
    //     username: username,
    //     email: data.email,
    //     gender:data.gender,
    //     password: data.password,
    //   })
    //   .subscribe(
    //     (response) => {
    //       // Set token Local Storage
    //       this.customLocalStorageService.addStorage('token', response.token);
    //       // Route Home page
    //       this.router.navigate(['']);
    //       this.spinnerService.hideSpinner(CustomSpinnerName.spinner_one);
    //     },
    //     (errorResponse: HttpErrorResponse) => {
    //       this.spinnerService.showSpinner(CustomSpinnerName.spinner_one);
    //       this.toastrService.alertMessage({
    //         title: `Hata ! -- ${errorResponse.status}`,
    //         message: 'Bilinmeyen Bir Hatayla Karşılaşıldı',
    //         position: ToastrPosition.TopRight,
    //         messageType: ToastrMessageType.Error,
    //       });
    //     }
    //   );
  }
  //  ====================== POST Register Operation ======================

  username(firstName: string, lastName: string) {
    const firsN = firstName.toLowerCase();
    const lastN = lastName.toLowerCase();

    return firsN + lastN;
  }

  // Toggle Eye Button Operation
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
}

export enum Genders {
  woman = 'kadın',
  men = 'erkek',
}
