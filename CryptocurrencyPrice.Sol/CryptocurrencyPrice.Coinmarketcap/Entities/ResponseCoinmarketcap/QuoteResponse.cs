using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CryptocurrencyPrice.Coinmarketcap.Entities.ResponseCoinmarketcap
{
    /// <summary>
    /// class to deserialize response coinmarketcap
    /// </summary>
    public class QuoteResponse
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("market_cap")]
        public double MarketCap { get; set; }

        [JsonProperty("volume_24h")]
        public double Volume24h { get; set; }

        [JsonProperty("volume_7d")]
        public double Volume7d { get; set; }

        [JsonProperty("percent_change_24h")]
        public double PercentChange24h { get; set; }

        [JsonProperty("percent_change_7d")]
        public double PercentChange7d { get; set; }

        [JsonProperty("total_supply")]
        public double TotalSupply { get; set; }
        
    }
}
