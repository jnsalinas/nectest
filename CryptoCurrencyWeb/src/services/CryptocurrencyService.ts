import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetCryptocurrencyQuotesMP } from 'src/models/MP/GetCryptocurrencyQuotesMP';
import { GetPriceConversionMP } from 'src/models/MP/GetPriceConversionMP';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CryptocurrencyService {
  constructor(private baseService: BaseService) {   }

  GetCryptocurrencyQuotes(): Observable<GetCryptocurrencyQuotesMP> {
    return this.baseService.executeGet("cryptocurrency/GetCryptocurrencyQuotes");
  }

  GetPriceConversion(): Observable<GetPriceConversionMP> {
    return this.baseService.executeGet("cryptocurrency/GetPriceConversion");
  }
  
}