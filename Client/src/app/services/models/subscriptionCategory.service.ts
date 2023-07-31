import { Injectable } from '@angular/core';
import {
  ControllerTypes,
  CustomHttpService,
} from '../common/custom-http.service';
import { SubscriptionCategoryModel } from 'src/app/models/subscriptionCategoryModel';
import { ListResponseModel } from '../../models/common/listResponseModel';

@Injectable({
  providedIn: 'root',
})
export class SubscriptionCategoryService {
  constructor(private httpClient: CustomHttpService) {}

  getAll() {
    return this.httpClient.get<SubscriptionCategoryModel[]>({
      controller: ControllerTypes.SubscriptionCategory,
    });
  }
}
