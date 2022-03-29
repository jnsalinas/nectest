import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetCryptocurrencyQuotesOut } from 'src/models/MP/GetCryptocurrencyQuotesOut';
import { GetPriceConversionOut } from 'src/models/MP/GetPriceConversionOut';
import { GetCryptocurrenciesOut } from 'src/models/MP/GetCryptocurrenciesOut';
import { BaseService } from './base.service';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CryptocurrencyService {
  constructor(private baseService: BaseService) {   }

  GetCryptocurrencyQuotes(cryptocurrencies: string): Observable<GetCryptocurrencyQuotesOut> {
    let params = new HttpParams().set('cryptocurrencies', cryptocurrencies);
    return this.baseService.executeGet("cryptocurrency/GetCryptocurrencyQuotes", params);
  }

  GetPriceConversion(crypto: string, amout: number): Observable<GetPriceConversionOut> {
    let params = new HttpParams().set('crypto', crypto).set('amount', amout);
    return this.baseService.executeGet("cryptocurrency/GetPriceConversion", params);
  }

  GetCryptocurrencies(): Observable<GetCryptocurrenciesOut> {
    return this.baseService.executeGet("cryptocurrency/GetCryptocurrencies");
  }

  
  
}