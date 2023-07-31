import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class CustomToastrService {
  constructor(private toastrService: ToastrService) {}

  alertMessage(toastrOptions: Partial<ToastrOptions>) {
    this.toastrService[toastrOptions.messageType](
      toastrOptions.message,
      toastrOptions.title,
      {
        positionClass: toastrOptions.position,
      }
    );
  }
}

export class ToastrOptions {
  messageType: ToastrMessageType;
  position: ToastrPosition;
  message?: string;
  title?: string;
}

export enum ToastrMessageType {
  Success = 'success',
  Info = 'info',
  Warning = 'warning',
  Error = 'error',
}

export enum ToastrPosition {
  TopRight = 'toast-top-right',
  BottomRight = 'toast-bottom-right',
  BottomLeft = 'toast-bottom-left',
  TopLeft = 'toast-top-left',
  TopFullWidth = 'toast-top-full-width',
  BottomFullWidth = 'toast-Bottom-full-width',
  TopCenter = 'toast-top-center',
  BottomCenter = 'toast-bottom-center',
}
