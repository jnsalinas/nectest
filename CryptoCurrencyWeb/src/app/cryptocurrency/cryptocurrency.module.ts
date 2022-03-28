import { NgModule } from '@angular/core';
import { CryptocurrencyRoutingModule } from './cryptocurrency-routing.module';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { InformationComponent } from './information/information.component';

@NgModule({
  declarations: [
    InformationComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    CryptocurrencyRoutingModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class CryptocurrencyModule { }
