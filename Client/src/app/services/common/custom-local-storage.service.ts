import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CustomLocalStorageService {
  constructor() {}

  addStorage(key: string, value: string) {
    return localStorage.setItem(key, value);
  }

  removeStorage(key: string) {
    return localStorage.removeItem(key);
  }

  clearStorage() {
    return localStorage.clear();
  }

  getItemStorage(key: string) {
    return localStorage.getItem(key);
  }
}
