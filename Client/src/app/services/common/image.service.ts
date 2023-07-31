import { Injectable } from '@angular/core';
import { ControllerTypes, CustomHttpService } from './custom-http.service';
import { ListResponseModel } from '../../models/common/listResponseModel';
import { ImageModel } from 'src/app/models/imageModel';

@Injectable({
  providedIn: 'root',
})
export class ImageService {
  constructor(private httpClient: CustomHttpService) {}

  private baseFileUrl: string = 'assets/img/';
  public foto_galery: string = `${this.baseFileUrl}foto_galery/`;

  //assets/img/foto_galery/

  getAllImage() {
    return this.httpClient.get<ImageModel[]>({
      controller: ControllerTypes.Images,
    });
  }
}
