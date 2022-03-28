using System;
namespace CryptocurrencyPrice.Entities.VM
{
    /// <summary>
    /// Virtual model to return information the values of cryptocurrencies
    /// </summary>
    public class QuoteVM
    {
        public double Price { get; set; }
        public double MarketCap { get; set; }
        public double Volume24h { get; set; }
        public double Volume7d { get; set; }
        public double PercentChange24h { get; set; }
        public double PercentChange7d { get; set; }
        public string Currency { get; set; }
    }
}
