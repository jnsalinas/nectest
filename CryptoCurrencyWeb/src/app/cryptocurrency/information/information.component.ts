import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Cryptocurrency } from 'src/models/VM/Cryptocurrency';
import { CryptocurrencyService } from 'src/services/CryptocurrencyService';

@Component({
  selector: 'app-information',
  templateUrl: './information.component.html',
  styleUrls: ['./information.component.css']
})
export class InformationComponent implements OnInit {
  formConversion = new FormGroup({
    crypto: new FormControl()
    , amount: new FormControl(0, Validators.required)
  });

  showLoader: boolean = true;
  listCryptocurrencyQuotesLatest: Cryptocurrency[] = [];
  conversionCrypto : Cryptocurrency = { listQuote : []};

  constructor(
    private cryoticurrencyService : CryptocurrencyService 
    ) { }

  ngOnInit(): void {
    this.GetCryptocurrencyQuotes();
    this.GetPriceConversion();
      // setInterval(() => {
      //   this.GetCryptocurrencyQuotes();
      // }, 5000);
  }


  GetCryptocurrencyQuotes(){
    this.cryoticurrencyService.GetCryptocurrencyQuotes()
    .subscribe(data => {
      if(data.result === 0){
        this.listCryptocurrencyQuotesLatest = data.listResult;
        console.log(this.listCryptocurrencyQuotesLatest);
        this.showLoader = false;
      }else{
        this.showLoader = false;
      }
    });
  }

  GetPriceConversion(){
    this.cryoticurrencyService.GetPriceConversion()
    .subscribe(data => {
      console.log("data", data);
      if(data.result === 0){
        this.conversionCrypto = data.entity;
      }else{
        this.showLoader = false;
      }
    });
  }
}
