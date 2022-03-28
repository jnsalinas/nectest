using System;
using System.Collections.Generic;
using CryptocurrencyPrice.Coinmarketcap.Entities;
using CryptocurrencyPrice.Entities.VM;

namespace CryptocurrencyPrice.Coinmarketcap.Interfaces
{
    public interface ICoinmarketcapBO
    {
        List<CryptocurrencyVM> GetCryptocurrencyQuotes(string currencies);
        CryptocurrencyVM GetPriceConversion(string crypto, double amount);
    }
}
