using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CryptocurrencyPrice.Coinmarketcap.Entities.ResponseCoinmarketcap
{
    /// <summary>
    /// class to deserialize response coinmarketcap
    /// </summary>
    public class StatusResponse
    {
        [JsonProperty("error_code")]
        public int Code { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
