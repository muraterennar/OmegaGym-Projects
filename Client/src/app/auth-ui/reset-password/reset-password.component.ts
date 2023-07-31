import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css'],
})
export class ResetPasswordComponent implements OnInit {
  submitted: boolean = false;
  resetPasswordForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private customToastrService: CustomToastrService,
    private spinner: CustomSpinnerService
  ) {}

  ngOnInit(): void {
    this.resetPasswordForm = this.formBuilder.group({
      email: ['', [Validators.email, Validators.required]],
    });
  }

  get resetPasswordComponent() {
    return this.resetPasswordForm.controls;
  }

  async send(data: any) {
    this.spinner.showSpinner(CustomSpinnerName.spinner_one);
    this.submitted = true;
    if (this.resetPasswordComponent.invalid) {
      this.spinner.hideSpinner(CustomSpinnerName.spinner_one);
      this.customToastrService.alertMessage({
        title: 'Eksik Bilgi',
        message: 'Bilgileri Eksiksiz Giriniz',
        messageType: ToastrMessageType.Info,
        position: ToastrPosition.BottomLeft,
      });
    }else{
      this.authService.resetTokenMailAsync(data.email, async () => {
        this.spinner.hideSpinner(CustomSpinnerName.spinner_one);
        this.customToastrService.alertMessage({
          title:"√ Gönderildi",
          message:"Mail Başarıyla Gönderildi",
          messageType:ToastrMessageType.Success,
          position:ToastrPosition.TopRight
        });
        await setTimeout(() => {
          this.router.navigate(['/giris']);
        }, 3000);
      });
    }



    this.spinner.hideSpinner(CustomSpinnerName.spinner_one);
  }
}
