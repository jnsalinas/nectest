import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InformationComponent } from './information/information.component';

const routes: Routes = [
  {
    path: 'Cryptocurrency',
        component: InformationComponent,
        data: {
          title: 'Cryptocurrencies'
        }
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CryptocurrencyRoutingModule { }
