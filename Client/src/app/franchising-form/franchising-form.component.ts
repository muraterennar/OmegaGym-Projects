import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { FranchisingService } from '../services/models/franchising.service';
import {
  CustomSpinnerName,
  CustomSpinnerService,
} from '../services/common/custom-spinner.service';
import {
  CustomToastrService,
  ToastrMessageType,
  ToastrPosition,
} from '../services/common/custom-toastr.service';
import { FranchisingModel } from '../models/franchisingModel';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-franchising-form',
  templateUrl: './franchising-form.component.html',
  styleUrls: ['./franchising-form.component.css'],
})
export class FranchisingFormComponent implements OnInit {
  francForm: FormGroup;
  submitted: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private franchisingService: FranchisingService,
    private customSpinner: CustomSpinnerService,
    private toastr: CustomToastrService
  ) {}

  ngOnInit(): void {
    this.francForm = this.formBuilder.group({
      firstName: [
        '',
        [
          Validators.required,
          Validators.maxLength(150),
          Validators.minLength(3),
        ],
      ],
      lastName: [
        '',
        [
          Validators.required,
          Validators.maxLength(150),
          Validators.minLength(3),
        ],
      ],
      email: [
        '',
        [
          Validators.required,
          Validators.maxLength(150),
          Validators.minLength(3),
          Validators.email,
        ],
      ],
      phone: [
        '',
        [
          Validators.required,
          Validators.maxLength(11),
          Validators.minLength(10),
        ],
      ],
    });

    this.francForm.get('phone').valueChanges.subscribe(() => {
      this.formatPhoneNumber();
    });
  }

  get francComponnent() {
    return this.francForm.controls;
  }

  onSubmit(data: FranchisingModel) {
    this.customSpinner.showSpinner(CustomSpinnerName.spinner_one);
    this.submitted = true;
    if (this.francForm.invalid) {
      this.franchisingService.Add(
        data,
        (response?: FranchisingModel) => {
          this.customSpinner.hideSpinner(CustomSpinnerName.spinner_one);
          this.toastr.alertMessage({
            title: 'Gönderildi',
            message: 'Talebiniz İletildi',
            messageType: ToastrMessageType.Success,
            position: ToastrPosition.BottomRight,
          });
        },
        (errorResponse?: HttpErrorResponse | any) => {
          this.customSpinner.hideSpinner(CustomSpinnerName.spinner_one);
          this.toastr.alertMessage({
            title: 'Talep Başarısız',
            message: 'Daha Sonra Tekrar Deneyin',
            messageType: ToastrMessageType.Error,
            position: ToastrPosition.BottomRight,
          });
        }
      );
    }

    this.customSpinner.hideSpinner(CustomSpinnerName.spinner_one);
  }

  formatPhoneNumber() {
    let phoneNumber = this.francForm.get('phone').value;

    // Telefon numarasındaki tüm boşlukları kaldırın
    phoneNumber = phoneNumber.replace(/\s+/g, '');

    // Telefon numarasının uzunluğuna göre uygun formata dönüştürün
    if (phoneNumber.length === 10) {
      phoneNumber = `${phoneNumber.substr(0, 3)} ${phoneNumber.substr(
        3,
        3
      )} ${phoneNumber.substr(6)}`;
    } else if (phoneNumber.length === 11) {
      phoneNumber = `${phoneNumber[0]} ${phoneNumber.substr(
        1,
        3
      )} ${phoneNumber.substr(4, 3)} ${phoneNumber.substr(7)}`;
    }

    this.francForm.get('phone').setValue(phoneNumber, { emitEvent: false });
  }
}
