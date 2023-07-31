import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';
import { initFlowbite } from 'flowbite';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    // ===== Sağ Tık Engelleme =======
    // document.addEventListener('contextmenu', (event) => {
    //   event.preventDefault();
    // });
    AOS.init({
      once: true,
      anchorPlacement: 'bottom-top',
    });

    initFlowbite();
  }
  title = 'OmegaGYM';
}
