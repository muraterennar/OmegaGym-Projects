import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UiComponent } from './ui.component';
import { UiComponentsModule } from './ui-components/ui-components.module';

@NgModule({
  declarations: [UiComponent],
  imports: [CommonModule, UiComponentsModule],
  exports: [UiComponent, UiComponentsModule],
})
export class UiModule {}
