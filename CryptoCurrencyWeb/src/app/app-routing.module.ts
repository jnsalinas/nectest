import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

export const routes: Routes = [
  { path: '',
  redirectTo: 'Cryptocurrency',
  pathMatch: 'full'
},
  {
    path: '',
    data: {
      title: 'Pruenas NEC Nicolas Salinas'
    },
    children: [
      {
        path: '',
        loadChildren: () => import('./cryptocurrency/cryptocurrency.module').then(m => m.CryptocurrencyModule)
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
