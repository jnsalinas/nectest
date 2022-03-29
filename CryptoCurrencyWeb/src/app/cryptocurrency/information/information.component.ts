import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Cryptocurrency } from 'src/models/VM/Cryptocurrency';
import { CryptocurrencyService } from 'src/services/CryptocurrencyService';
import { environment } from '../../../environments/environment';
import { ToastrService } from 'ngx-toastr';
import { ThrowStmt } from '@angular/compiler';
import { Result } from 'src/models/base/Result';

@Component({
  selector: 'app-information',
  templateUrl: './information.component.html',
  styleUrls: ['./information.component.css']
})
export class InformationComponent implements OnInit {
  formConversion = new FormGroup({
    crypto: new FormControl(null, Validators.required)
    , amount: new FormControl(null, Validators.required)
  });

  showLoader: boolean = true;
  listCryptocurrencies: Cryptocurrency[] = [];
  listCryptocurrencyQuotesLatest: Cryptocurrency[] = [];
  conversionCrypto : Cryptocurrency = { listQuote : []};

  constructor(
    private cryoticurrencyService : CryptocurrencyService,
    private toastr: ToastrService
    ) { }

  ngOnInit(): void {
    this.GetCryptocurrencies();
    this.GetCryptocurrencyQuotes();
     
    setInterval(() => {
      this.GetCryptocurrencyQuotes();
    }, 5000);
  }

  GetCryptocurrencyQuotes(){
    this.showLoader = true;
    this.cryoticurrencyService.GetCryptocurrencyQuotes(environment.DefaultCryptocurrenciesList)
    .subscribe(data => {
      if(data.result === 0){
        this.listCryptocurrencyQuotesLatest = data.listResult;
        this.showLoader = false;
      }
      else if(data.result === Result.ConnectionApiError){
        this.ShowError("Error al consumir el servicio - Últimas cotizaciones");
      }else{
        this.showLoader = false;
      }
    });
  }

  GetPriceConversion(){
    this.showLoader = true;
    if(this.formConversion.valid){
      let crptoSelected = this.formConversion.value.crypto;
      let amount = this.formConversion.value.amount;
      
      this.cryoticurrencyService.GetPriceConversion(crptoSelected, amount)
      .subscribe(data => {
        if(data.result === 0){
          this.conversionCrypto = data.entity;
        }
        else if(data.result === Result.ConnectionApiError){
          this.ShowError("Error al consumir el servicio - Conversión crypto");
        }
        else{
          this.ShowError();
        }

        this.showLoader = false;
      });
    }else{
      this.ShowWarning("Por favor digite la información del formulario");
      this.showLoader = false;
    }

  }

  ShowError(message: string = "Ocurrio un error, por favor intente de nuevo") {
    this.toastr.warning(message);
  }

  ShowWarning(message: string) {
    this.toastr.warning(message)
  }

  GetCryptocurrencies(){
    this.cryoticurrencyService.GetCryptocurrencies()
    .subscribe(data => {
      if(data.result === Result.Success){
        this.listCryptocurrencies = data.listResult;
      }else if(data.result === Result.ConnectionApiError){
        this.ShowError("Error al consumir el servicio -  Lista de cryptos");
      }
      else {
        this.ShowError();
      }
      this.showLoader = false;
    });
  }
}
