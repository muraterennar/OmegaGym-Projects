import { Injectable } from '@angular/core';
import {
  ControllerTypes,
  CustomHttpService,
} from '../common/custom-http.service';
import { SubscriptionModel } from 'src/app/models/subscriptionModel';
import { SubscriptionDetailModel } from 'src/app/models/subscriptionDetailModel';
import { ListResponseModel } from '../../models/common/listResponseModel';

@Injectable({
  providedIn: 'root',
})
export class SubscriptionService {
  constructor(private customHttpClient: CustomHttpService) {}

  getAll() {
    return this.customHttpClient.get<SubscriptionModel[]>({
      controller: ControllerTypes.subscriptions,
    });
  }

  getByDetails(categoryName: string) {
    return this.customHttpClient.get<SubscriptionDetailModel[]>({
      controller: ControllerTypes.subscriptions,
      action: 'details',
      queryString: `CategoryName=${categoryName}`,
    });
  }

  // getByFitness(categoryId: string) {
  //   return this.customHttpClient.get<ListResponseModel<SubscriptionModel>>({
  //     controller:ControllerTypes.subscriptions,
  //     action:
  //   })
  // }
}
