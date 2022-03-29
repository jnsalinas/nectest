import { NgModule } from '@angular/core';
import { CryptocurrencyRoutingModule } from './cryptocurrency-routing.module';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { InformationComponent } from './information/information.component';
import { ToastrModule } from 'ngx-toastr';

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
    SharedModule,
    ToastrModule.forRoot(),
  ]
})
export class CryptocurrencyModule { }
