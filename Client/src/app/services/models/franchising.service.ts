import { Injectable } from '@angular/core';
import {
  ControllerTypes,
  CustomHttpService,
} from '../common/custom-http.service';
import { FranchisingModel } from 'src/app/models/franchisingModel';
import { Observable, firstValueFrom } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class FranchisingService {
  constructor(private customHttpService: CustomHttpService) {}

  async Add(
    franchisingModel: Partial<FranchisingModel>,
    successCallBackFunction?: (response?: FranchisingModel) => void,
    errorCallBackFunction?: (error?: HttpErrorResponse | any) => void
  ): Promise<FranchisingModel | any> {
    const observable: Observable<FranchisingModel> =
      this.customHttpService.post(
        {
          controller: ControllerTypes.Franchising,
          action: ControllerTypes.Add,
        },
        franchisingModel
      );

    const promiseData: Promise<FranchisingModel> = firstValueFrom(observable);
    promiseData
      .then((response?: FranchisingModel) => {
        successCallBackFunction(response);
      })
      .catch((errorResponse?: HttpErrorResponse | any) => {
        errorCallBackFunction(errorResponse);
      });

    await promiseData;
  }

  async Delete(
    id: string,
    successCallBackFunction?: (response?: any) => void,
    errorCallBackFunction?: (error?: HttpErrorResponse | any) => void
  ): Promise<any> {
    const observable: Observable<any> = this.customHttpService.post(
      {
        controller: ControllerTypes.Franchising,
        action: ControllerTypes.Add,
      },
      id
    );

    const promiseData: Promise<any> = firstValueFrom(observable);
    promiseData
      .then((response?: any) => {
        successCallBackFunction(response);
      })
      .catch((errorResponse?: HttpErrorResponse | any) => {
        errorCallBackFunction(errorResponse);
      });

    await promiseData;
  }
}
