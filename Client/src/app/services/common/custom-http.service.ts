import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CustomHttpService {
  constructor(
    private httpClient: HttpClient,
    @Inject('baseUrl') private baseUrl: string
  ) {}

  private url(requestParameter: Partial<RequestParameters>): string {
    return `${
      requestParameter.baseUrl ? requestParameter.baseUrl : this.baseUrl
    }/${requestParameter.controller}${
      requestParameter.action ? `/${requestParameter.action}` : ''
    }`;
  }

  get<T>(
    requestParameter: Partial<RequestParameters>,
    id?: string
  ): Observable<T> {
    let url: string = '';
    if (requestParameter.fullEndPoint) url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${id ? `/${id}` : ''}${
        requestParameter.queryString ? `?${requestParameter.queryString}` : ''
      }`;

    return this.httpClient.get<T>(url, {
      headers: requestParameter.headers,
      responseType: requestParameter.responseType as 'json',
    });
  }

  post<T>(
    requestParameter: Partial<RequestParameters>,
    body: Partial<T>
  ): Observable<T> {
    let url: string = '';
    if (requestParameter.fullEndPoint) url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${
        requestParameter.queryString ? `?${requestParameter.queryString}` : ''
      }`;

    return this.httpClient.post<T>(url, body, {
      headers: requestParameter.headers,
      responseType: requestParameter.responseType as 'json',
    });
  }

  postAuth<T, X>(
    requestParameter: Partial<RequestParameters>,
    body: Partial<T>
  ): Observable<X> {
    let url: string = '';
    if (requestParameter.fullEndPoint) url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${
        requestParameter.queryString ? `?${requestParameter.queryString}` : ''
      }`;

    return this.httpClient.post<X>(url, body, {
      headers: requestParameter.headers,
      responseType: requestParameter.responseType as 'json',
    });
  }

  put<T>(
    requestParameter: Partial<RequestParameters>,
    body: Partial<T>
  ): Observable<T> {
    let url: string = '';
    if (requestParameter.fullEndPoint) url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}${
        requestParameter.queryString ? `?${requestParameter.queryString}` : ''
      }`;

    return this.httpClient.put<T>(url, body, {
      headers: requestParameter.headers,
      responseType: requestParameter.responseType as 'json',
    });
  }

  delete<T>(
    requestParameter: Partial<RequestParameters>,
    id: string
  ): Observable<T> {
    let url: string = '';
    if (requestParameter.fullEndPoint) url = requestParameter.fullEndPoint;
    else
      url = `${this.url(requestParameter)}/${id}${
        requestParameter.queryString ? `?${requestParameter.queryString}` : ''
      }`;

    return this.httpClient.delete<T>(url, {
      headers: requestParameter.headers,
      responseType: requestParameter.responseType as 'json',
    });
  }
}

export class RequestParameters {
  controller?: string;
  action?: string;
  queryString?: string;

  headers?: HttpHeaders;
  baseUrl?: string;
  fullEndPoint?: string;

  responseType?: string = 'json';
}

export enum ControllerTypes {
  users = 'users',
  subscriptions = 'subscriptions',
  SubscriptionCategory = 'SubscriptionCategories',
  Auth = 'Auth',
  Images = 'images',
  Mails = 'Mails',
  Franchising ="Franchisings",


  // Actions
  Add = "add",
  delete = "delete",
  ResetPasswordAction="password-reset",
  VerifyResetTokenAction = "verify-reset-token",
  sendSingleCodeAction = "send-single-code",
  twoFactorAction = "two-factor-auth",
}
