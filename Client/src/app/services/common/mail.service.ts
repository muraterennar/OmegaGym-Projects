import { Injectable } from '@angular/core';
import { ControllerTypes, CustomHttpService } from './custom-http.service';
import { MailModel } from 'src/app/models/common/mailModel';

@Injectable({
  providedIn: 'root',
})
export class MailService {
  constructor(private httpClient: CustomHttpService) {}

  private to: MailTo.test;

  sendMail(datas: Partial<MailModel>) {
    return this.httpClient.post<Partial<MailModel>>(
      {
        controller: ControllerTypes.Mails,
        queryString: `Tos=${datas.tos}&Subject=${datas.subject}&Body=${datas.body}&IsBodyHtml=${datas.isBodyHtml}`,
      },
      datas
    );
  }

  singleSendMail(datas: Partial<MailModel>) {
    return this.httpClient.post<Partial<MailModel>>(
      {
        controller: ControllerTypes.Mails,
        // queryString: `Tos=${this.to}&Subject=${datas.subject}&Body=${datas.body}&IsBodyHtml=${datas.isBodyHtml}`,
      },
      {
        tos: datas.tos,
        subject: datas.subject,
        body: datas.body,
        isBodyHtml: datas.isBodyHtml,
      }
    );
  }
}

export enum MailTo {
  //TODO: Canlıya alınırken düzeltilecek
  test = 'muraterennar@gmail.com',
  release = '',
}
