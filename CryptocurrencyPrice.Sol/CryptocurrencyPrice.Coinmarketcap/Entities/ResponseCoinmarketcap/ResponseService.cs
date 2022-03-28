using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CryptocurrencyPrice.Coinmarketcap.Entities.ResponseCoinmarketcap
{
    /// <summary>
    /// class to deserialize response coinmarketcap
    /// </summary>
    public class ResponseService
    {
        [JsonProperty("status")]
        public StatusResponse Status { get; set; }

        [JsonProperty("data")]
        public dynamic Data { get; set; }

    }
}
