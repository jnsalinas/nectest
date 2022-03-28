import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetCryptocurrencyQuotesLatestMP } from 'src/models/MP/GetCryptocurrencyQuotesLatestMP';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CryptocurrencyService {
  constructor(private baseService: BaseService) {   }

  GetCryptocurrencyQuotesLatestMP(): Observable<GetCryptocurrencyQuotesLatestMP> {
    return this.baseService.executeGet("cryptocurrency/GetCryptocurrencyQuotes");
  }
}
