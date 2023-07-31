import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.css'],
})
export class AdminLayoutComponent {
  openSidebar(openId: HTMLDivElement) {
    openId.classList.remove('sidebar-translate-close');
    openId.classList.add('sidebar-translate-open');
  }
}
