import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './admin-sidebar.component.html',
  styleUrls: ['./admin-sidebar.component.css'],
})
export class AdminSidebarComponent {
  close() {
    const sidebar: HTMLElement = document.getElementById('admin_sidebar');
    sidebar.classList.remove('sidebar-translate-open');
    sidebar.classList.add('sidebar-translate-close');
  }
}
