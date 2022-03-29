using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using CryptocurrencyPrice.Business.Interfaces;
using CryptocurrencyPrice.Coinmarketcap.BO;
using CryptocurrencyPrice.Coinmarketcap.Entities;
using CryptocurrencyPrice.Coinmarketcap.Interfaces;
using CryptocurrencyPrice.Entities.MP;
using CryptocurrencyPrice.Entities.VM;
using CryptocurrencyPrice.Utilities.Helper;

namespace CryptocurrencyPrice.Business.BO
{
    public class CryptocurrencyBO : ICryptocurrencyBO
    {
        private readonly ICoinmarketcapBO _iCoinmarketcapBO;

        public CryptocurrencyBO(ICoinmarketcapBO iCoinmarketcapBO)
        {
            _iCoinmarketcapBO = iCoinmarketcapBO;
        }


        /// <summary>
        /// return information to cryptocurrencies
        /// </summary>
        /// <param name="cryptocurrencies"></param>
        /// <returns></returns>
        public GetCryptocurrenciesOut GetCryptocurrencies()
        {
            List<CryptocurrencyVM> responseCoinMarketcap = _iCoinmarketcapBO.GetCryptocurrencies();

            return new GetCryptocurrenciesOut()
            {
                ListResult = responseCoinMarketcap
            };
        }

        /// <summary>
        /// return information to cryptocurrencies
        /// </summary>
        /// <param name="cryptocurrencies"></param>
        /// <returns></returns>
        public GetCryptocurrencyQuotesLatestOut GetCryptocurrencyQuotes(string cryptocurrencies)
        {
            List<CryptocurrencyVM> responseCoinMarketcap = _iCoinmarketcapBO.GetCryptocurrencyQuotes(cryptocurrencies);

            return new GetCryptocurrencyQuotesLatestOut() {
                 ListResult = responseCoinMarketcap
            };
        }

        /// <summary>
        /// convert crypto value
        /// </summary>
        /// <param name="crypto"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public GetPriceConversionOut GetPriceConversion(string crypto, double amount)
        {
            CryptocurrencyVM responsePriceConversion = _iCoinmarketcapBO.GetPriceConversion(crypto, amount);

            return new GetPriceConversionOut()
            {
                Entity = responsePriceConversion
            };
        }

    }
}
