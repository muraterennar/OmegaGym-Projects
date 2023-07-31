import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpStatusCode,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, of } from 'rxjs';
import {
  CustomToastrService,
  ToastrMessageType,
  ToastrPosition,
} from './custom-toastr.service';
import {
  CustomSpinnerName,
  CustomSpinnerService,
} from './custom-spinner.service';

@Injectable({
  providedIn: 'root',
})
export class CustomHttpErrorHandlerIntercepterService
  implements HttpInterceptor
{
  constructor(
    private customToastr: CustomToastrService,
    private customSpinner: CustomSpinnerService
  ) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error) => {
        switch (error.status) {
          case HttpStatusCode.InternalServerError:
            this.customSpinner.showSpinner(CustomSpinnerName.Page500);
            break;

          case 0:
            this.customSpinner.showSpinner(CustomSpinnerName.Page500);
            break;

          case HttpStatusCode.NotFound:
            this.customSpinner.showSpinner(CustomSpinnerName.Page404);
            break;

          case HttpStatusCode.Unauthorized:
            this.customToastr.alertMessage({
              title: 'Yekisiz İşlem',
              message: 'Giriş Yapmalısınız',
              messageType: ToastrMessageType.Info,
              position: ToastrPosition.BottomRight,
            });
            break;

          case HttpStatusCode.BadRequest:
            this.customToastr.alertMessage({
              title: 'Başarısız İstek',
              message: 'Tekrar Deneyin',
              messageType: ToastrMessageType.Info,
              position: ToastrPosition.BottomRight,
            });
            break;

          default:
            this.customSpinner.showSpinner(CustomSpinnerName.PageUnknown);
            break;
        }
        return of(error);
      })
    );
  }
}
