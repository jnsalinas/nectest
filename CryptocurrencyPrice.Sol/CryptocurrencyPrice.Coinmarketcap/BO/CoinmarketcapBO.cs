using System;
using CryptocurrencyPrice.Coinmarketcap.Interfaces;
using Microsoft.Extensions.Configuration;
using CryptocurrencyPrice.Utilities.Helper;
using System.Collections.Generic;
using System.Web;
using CryptocurrencyPrice.Coinmarketcap.Entities;
using Newtonsoft.Json;
using System.Linq;
using CryptocurrencyPrice.Coinmarketcap.Entities.ResponseCoinmarketcap;
using CryptocurrencyPrice.Entities.VM;
using System.Collections;
using AutoMapper;

namespace CryptocurrencyPrice.Coinmarketcap.BO
{
    public class CoinmarketcapBO : ICoinmarketcapBO
    {
        #region properties
        private Dictionary<string, string> headers = new Dictionary<string, string>();
        private static string _apiKey;
        private static string _apiURL;
        private static string _headerApiKeyName;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        /// <summary>
        /// Assigns defaults values to consume coinmarketcap services
        /// </summary>
        /// <param name="configuration">app settings configurations</param>
        /// <param name="mapper">mapper to optmize convertions</param>
        public CoinmarketcapBO(IConfiguration configuration, IMapper mapper)
        {
            _apiURL = configuration["Coinmarketcap:ApiURL"];
            _apiKey = configuration["Coinmarketcap:ApiKey"];
            _headerApiKeyName = configuration["Coinmarketcap:HeaderApiKeyName"];
            _mapper = mapper;
            headers.Add(_headerApiKeyName, _apiKey);
        }
        #endregion

        #region public methods

        public List<CryptocurrencyVM> GetCryptocurrencies()
        {
            #region create url
            var URL = new UriBuilder(_apiURL + "cryptocurrency/map"); 
            #endregion

            ResponseService response = HttpRequestHelper.GetRequest<ResponseService>(URL.ToString(), headers).Result;
            List<CryptocurrencyVM> listCryptocurrencyVM = new List<CryptocurrencyVM>();
            if (response.Status != null && response.Status.Code.Equals(0))
            {
                listCryptocurrencyVM = JsonConvert.DeserializeObject<List<CryptocurrencyVM>>(response.Data.ToString());
            }

            return listCryptocurrencyVM;
        }

        /// <summary>
        /// Request cryptocurrency/quotes/latest and return information with internal estructure
        /// </summary>
        /// <param name="currencies"></param>
        /// <returns></returns>
        public List<CryptocurrencyVM> GetCryptocurrencyQuotes(string currencies)
        {
            #region create url
            var URL = new UriBuilder(_apiURL + "cryptocurrency/quotes/latest"); // Coinmarketcap deprecated version 1
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = currencies;
            URL.Query = queryString.ToString();
            #endregion

            ResponseService response = HttpRequestHelper.GetRequest<ResponseService>(URL.ToString(), headers).Result;

            #region map internal response
            List<CryptocurrencyVM> listCriptocurrencies = new List<CryptocurrencyVM>();

            if (response.Status != null && response.Status.Code.Equals(0))
            {
                CryptocurrencyVM newCryptocurrencyVM;
                QuoteResponse quoteResponseUSD;
                CryptocurrencyResponse itemCryptocurrencyResponse;
                QuoteVM itemQuoteVM;
                foreach (var item in currencies.Split(',').ToList())
                {
                    //problems with structure response, with objects dynamics and deserialize objects this problem is solve
                    itemCryptocurrencyResponse = JsonConvert.DeserializeObject<CryptocurrencyResponse>(response.Data[item].ToString());
                    quoteResponseUSD = JsonConvert.DeserializeObject<QuoteResponse>(itemCryptocurrencyResponse.Quote["USD"].ToString());

                    newCryptocurrencyVM = _mapper.Map<CryptocurrencyVM>(itemCryptocurrencyResponse);
                    itemQuoteVM = _mapper.Map<QuoteVM>(quoteResponseUSD);
                    itemQuoteVM.Currency = "USD";
                    newCryptocurrencyVM.ListQuote = new List<QuoteVM>() { itemQuoteVM };

                    listCriptocurrencies.Add(newCryptocurrencyVM);
                }
            }
            else
                throw new Exception($"Coinmarketcap service error, code {response.Status.Code} error message: {response.Status.ErrorMessage}");
            #endregion

            return listCriptocurrencies;

        }

        /// <summary>
        /// Request price-conversion for convert crypto value
        /// </summary>
        /// <param name="crypto"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public CryptocurrencyVM GetPriceConversion(string crypto, double amount)
        {
            #region create url
            var URL = new UriBuilder(_apiURL + "tools/price-conversion");
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["symbol"] = crypto;
            queryString["amount"] = amount.ToString();
            URL.Query = queryString.ToString();
            #endregion

            ResponseService response = HttpRequestHelper.GetRequest<ResponseService>(URL.ToString(), headers).Result;

            #region map internal response
            CryptocurrencyVM cryptocurrencyVM = new CryptocurrencyVM();

            if (response.Status != null && response.Status.Code.Equals(0))
            {
                CryptocurrencyResponse itemCryptocurrencyResponse = JsonConvert.DeserializeObject<CryptocurrencyResponse>(response.Data[crypto].ToString());
                cryptocurrencyVM = _mapper.Map<CryptocurrencyVM>(itemCryptocurrencyResponse);
                cryptocurrencyVM.ListQuote = new List<QuoteVM>();

                var listPriceConversion = ((IEnumerable)itemCryptocurrencyResponse.Quote).Cast<dynamic>().ToList();

                foreach (var item in listPriceConversion)
                {
                    QuoteVM quoteResponse = JsonConvert.DeserializeObject<QuoteVM>(item.Value.ToString());
                    quoteResponse.Currency = item.Name;
                    cryptocurrencyVM.ListQuote.Add(quoteResponse);
                }
            }
            else
                throw new Exception($"Coinmarketcap service error, code {response.Status.Code} error message: {response.Status.ErrorMessage}");

            #endregion

            return cryptocurrencyVM;
        }
        #endregion
    }
}
