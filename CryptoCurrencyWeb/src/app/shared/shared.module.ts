import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from './spinner/spinner.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    SpinnerComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    SpinnerComponent
  ]
})
export class SharedModule { }
