import { Inject, Injectable } from '@angular/core';
import { ControllerTypes, CustomHttpService } from './custom-http.service';
import { CustomLocalStorageService } from './custom-local-storage.service';
import { AuthLoginModel } from 'src/app/models/authLoginModel';
import { AuthTokenModel } from 'src/app/models/common/AuthTokenModel';
import { Observable, firstValueFrom } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { AuthRegisterModel } from 'src/app/models/authRegisterModel';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private customLocalStorageService: CustomLocalStorageService,
    private customHttpClient: CustomHttpService,
    @Inject('baseUrl') private baseUrl: string
  ) {}

  login(loginModel: Partial<AuthLoginModel>) {
    return this.customHttpClient.postAuth<AuthLoginModel, AuthTokenModel>(
      {
        controller: ControllerTypes.Auth,
        action: 'login',
      },
      {
        email: loginModel.email,
        password: loginModel.password,
      }
    );
  }

  register(registerModel: Partial<AuthRegisterModel>) {
    return this.customHttpClient.postAuth<AuthRegisterModel, AuthTokenModel>(
      {
        controller: ControllerTypes.Auth,
        action: 'register',
      },
      {
        firstName: registerModel.firstName,
        lastName: registerModel.lastName,
        username: registerModel.username,
        email: registerModel.email,
        gender:registerModel.gender,
        password: registerModel.password,
      }
    );
  }

  async registerAync(
    registerModel: Partial<AuthRegisterModel>,
    successCallBack?: (response?: any) => void,
    errorCallBack?: (errorResponse?: any) => void
  ): Promise<any> {
    debugger;
    const observable: Observable<AuthRegisterModel | any> =
      this.customHttpClient.postAuth<AuthRegisterModel, AuthTokenModel>(
        {
          controller: ControllerTypes.Auth,
          action: 'register',
        },
        {
          firstName: registerModel.firstName,
          lastName: registerModel.lastName,
          username: registerModel.username,
          email: registerModel.email,
          gender: registerModel.gender,
          password: registerModel.password,
        }
      );

    const promiseData: Promise<any> = firstValueFrom(observable);
    promiseData
      .then((response?: any) => {
        successCallBack(response);
      })
      .catch((errorResponse: HttpErrorResponse | any) => {
        errorCallBack(errorResponse);
      });

    await promiseData;
  }

  async loginAsync(
    loginModel: Partial<AuthLoginModel>,
    successCllBackFunction?: (response?: any) => void,
    errorCllBackFunction?: (error?: any) => void
  ) {
    const observable: Observable<AuthLoginModel | AuthTokenModel> =
      this.customHttpClient.postAuth<AuthLoginModel, AuthTokenModel>(
        {
          controller: ControllerTypes.Auth,
          action: 'login',
        },
        {
          email: loginModel.email,
          password: loginModel.password,
        }
      );

    const promiseData: Promise<any> = firstValueFrom(observable);
    promiseData
      .then((response?: any) => {
        successCllBackFunction(response);
      })
      .catch((errorResponse?: any) => {
        errorCllBackFunction(errorResponse);
      });

    await promiseData;
  }

  async resetTokenMailAsync(email: string, callBackFunction?: () => void) {
    const observable: Observable<{ email: string }> =
      this.customHttpClient.post(
        {
          controller: ControllerTypes.Auth,
          action: ControllerTypes.ResetPasswordAction,
        },
        { email: email }
      );

    await firstValueFrom(observable);
    callBackFunction();
  }

  async verifyResetToken(
    resetToken: string,
    userId: string,
    callBackFunction?: () => void
  ): Promise<boolean> {
    const observable: Observable<{ resetToken: string; userId: string } | any> =
      this.customHttpClient.post(
        {
          controller: ControllerTypes.Auth,
          action: ControllerTypes.VerifyResetTokenAction,
        },
        {
          resetToken: resetToken,
          userId: userId,
        }
      );

    const state = await firstValueFrom(observable);
    callBackFunction();
    return state;
  }

  async sendSingleCodeToMail(
    toEmail: string,
    successCallBackDunction?: (response?: string) => void,
    errorCallBackFunction?: (error?: any) => void
  ): Promise<any> {
    const observable: Observable<{ email: string }> =
      this.customHttpClient.post(
        {
          controller: ControllerTypes.Auth,
          action: ControllerTypes.sendSingleCodeAction,
        },
        {
          email: toEmail,
        }
      );

    const promiseData: Promise<any> = firstValueFrom(observable);
    promiseData
      .then((response?: any) => {
        successCallBackDunction(response);
      })
      .catch((errorRespone: HttpErrorResponse | any) => {
        errorCallBackFunction(errorRespone);
      });

    await promiseData;
  }

  async twoFactorAuth(
    toEmail: string,
    getSingleCode: string,
    successCllBackFunction?: (response?: any) => void,
    errorCallBackFunction?: (errorResponse: any) => void
  ): Promise<any> {
    const observable: Observable<{ email: string; singleCode: string }> =
      this.customHttpClient.post(
        {
          controller: ControllerTypes.Auth,
          action: ControllerTypes.twoFactorAction,
        },
        {
          email: toEmail,
          singleCode: getSingleCode,
        }
      );

    const promiseData: Promise<any> = firstValueFrom(observable);
    promiseData
      .then((response?: any) => {
        successCllBackFunction(response);
      })
      .catch((errorResponse?: HttpErrorResponse | any) => {
        errorCallBackFunction(errorResponse);
      });

    await promiseData;
  }
}
