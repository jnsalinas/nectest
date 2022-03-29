using System;
using CryptocurrencyPrice.Coinmarketcap.Entities;
using CryptocurrencyPrice.Entities.MP;

namespace CryptocurrencyPrice.Business.Interfaces
{
    public interface ICryptocurrencyBO
    {
        GetCryptocurrencyQuotesLatestOut GetCryptocurrencyQuotes(string cryptocurrencies);
        GetCryptocurrenciesOut GetCryptocurrencies();
        GetPriceConversionOut GetPriceConversion(string crypto, double amount);
    }
}
