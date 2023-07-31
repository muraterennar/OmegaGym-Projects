import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/common/auth.service';
import {
  CustomSpinnerName,
  CustomSpinnerService,
} from 'src/app/services/common/custom-spinner.service';
import {
  CustomToastrService,
  ToastrMessageType,
  ToastrPosition,
} from 'src/app/services/common/custom-toastr.service';
import { UserService } from 'src/app/services/models/user.service';

@Component({
  selector: 'app-update-password',
  templateUrl: './update-password.component.html',
  styleUrls: ['./update-password.component.css'],
})
export class UpdatePasswordComponent implements OnInit {
  submitted: boolean = false;
  updatePasswordForm: FormGroup;
  state: any;

  constructor(
    private formBuilder: FormBuilder,
    private spinner: CustomSpinnerService,
    private toastr: CustomToastrService,
    private authService: AuthService,
    private activatedRoute: ActivatedRoute,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.spinner.showSpinner(CustomSpinnerName.spinner_one);
    this.activatedRoute.params.subscribe({
      next: async (params) => {
        const userId: string = params['userId'];
        const resetToken: string = params['resetToken'];

        this.state = await this.authService.verifyResetToken(
          resetToken,
          userId,
          () => {
            this.spinner.hideSpinner(CustomSpinnerName.spinner_one);
          }
        );
      },
    });

    this.updatePasswordForm = this.formBuilder.group(
      {
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(6),
            Validators.max(12),
            this.passwordValidator,
          ],
        ],
        passwordConfirm: ['', [Validators.required]],
      },
      { validators: this.matchPasswords }
    );

    this.spinner.hideSpinner(CustomSpinnerName.spinner_one);
  }

  // Password Confirm Operation
  matchPasswords(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password').value;
    const confirmPassword = control.get('passwordConfirm').value;

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

  get updatePasswordComponent() {
    return this.updatePasswordForm.controls;
  }

  onSubmit(data: any) {
    this.spinner.showSpinner(CustomSpinnerName.spinner_one);
    this.submitted = true;
    if (
      this.updatePasswordForm.invalid ||
      this.updatePasswordForm.hasError('mismatch')
    ) {
      this.spinner.hideSpinner(CustomSpinnerName.spinner_one);
      this.toastr.alertMessage({
        title: 'Doğrulama Hatası',
        message: 'Litfen Bilgileri Doğru Girin',
        messageType: ToastrMessageType.Info,
        position: ToastrPosition.TopRight,
      });
    } else {
      this.spinner.hideSpinner(CustomSpinnerName.spinner_one);
      this.activatedRoute.params.subscribe({
        next: async (params) => {
          const userId = params['userId'];
          const resetToken = params['resetToken'];

          await this.userService.updatePassword(
            userId,
            resetToken,
            data.password,
            data.passwordConfirm,
            () => {
              this.toastr.alertMessage({
                title: '√ Güncellendi',
                message: 'Şifreniz Başarıyla Güncellendi',
                messageType: ToastrMessageType.Success,
                position: ToastrPosition.TopRight,
              });

              setTimeout(() => {
                this.router.navigate(['/giris']);
              }, 3000);
            },
            (error: any) => {
              this.toastr.alertMessage({
                title: 'Hata !',
                message: 'Bilinmeyen Bir Hata Daha Sonra Tekrar Deneyin',
                messageType: ToastrMessageType.Error,
                position: ToastrPosition.TopRight,
              });
            }
          );
        },
      });
    }

    this.spinner.hideSpinner(CustomSpinnerName.spinner_one);
  }
}
