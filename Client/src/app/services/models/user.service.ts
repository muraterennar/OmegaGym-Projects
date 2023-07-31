import { Injectable } from '@angular/core';
import {
  ControllerTypes,
  CustomHttpService,
} from '../common/custom-http.service';
import { Observable, firstValueFrom } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private customHttpClient: CustomHttpService) {}

  async updatePassword(
    userId: string,
    resetToken: string,
    newPassword: string,
    passwordConfirm: string,
    successCllBackFunction?: (response?:any) => void,
    errorCllBackFunction?: (error: any) => void
  ) {
    const observable: Observable<{
      userId: string;
      resetToken: string;
      newPassword: string;
      passwordConfirm: string;
    }> = this.customHttpClient.post(
      {
        controller: ControllerTypes.users,
        action: 'update-password',
      },
      {
        userId: userId,
        resetToken: resetToken,
        newPassword: newPassword,
        passwordConfirm: passwordConfirm,
      }
    );

    const promiseData: Promise<any> = firstValueFrom(observable);
    promiseData
      .then((response?:any) => {
        successCllBackFunction(response);
      })
      .catch((errorResponse: any) => {
        errorCllBackFunction(errorResponse);
      });

      await promiseData;
  }
}
