using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CryptocurrencyPrice.Coinmarketcap.Entities.ResponseCoinmarketcap
{
    /// <summary>
    /// class to deserialize response coinmarketcap service for each crypto
    /// </summary>
    public class CryptocurrencyResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("quote")]
        public dynamic Quote { get; set; }

        [JsonProperty("name")]
        public dynamic Name { get; set; }

        [JsonProperty("circulating_supply")]
        public double CirculatingSupply { get; set; }

    }
}