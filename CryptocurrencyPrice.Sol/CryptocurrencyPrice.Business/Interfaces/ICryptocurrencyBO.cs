using System;
using CryptocurrencyPrice.Coinmarketcap.Entities;
using CryptocurrencyPrice.Entities.MP;

namespace CryptocurrencyPrice.Business.Interfaces
{
    public interface ICryptocurrencyBO
    {
        GetCryptocurrencyQuotesLatestMP GetCryptocurrencyQuotes(string cryptocurrencies);
        GetPriceConversionMP GetPriceConversion(string crypto, double amount);
    }
}
