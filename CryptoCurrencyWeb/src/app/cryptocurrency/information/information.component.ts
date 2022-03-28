import { Component, OnInit } from '@angular/core';
import { Cryptocurrency } from 'src/models/VM/Cryptocurrency';
import { CryptocurrencyService } from 'src/services/CryptocurrencyService';

@Component({
  selector: 'app-information',
  templateUrl: './information.component.html',
  styleUrls: ['./information.component.css']
})
export class InformationComponent implements OnInit {
  showLoader: boolean = true;
  listCryptocurrencyQuotesLatest: Cryptocurrency[] = [];
  constructor(
    private cryoticurrencyService : CryptocurrencyService 
    ) { }

  ngOnInit(): void {
    this.Get();
  }
  

  Get(){
    this.cryoticurrencyService.GetCryptocurrencyQuotesLatestMP().subscribe(data => {
      if(data.result === 0){
        this.listCryptocurrencyQuotesLatest = data.listResult;
        console.log(this.listCryptocurrencyQuotesLatest);
        this.showLoader = false;
      }else{
        console.log("error");
        this.showLoader = false;
      }
    });
  }
}
