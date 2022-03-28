using System;
using System.Collections.Generic;

namespace CryptocurrencyPrice.Entities.VM
{
    /// <summary>
    /// Vritual Model to map response information about the cryptocurrencies
    /// </summary>
    public class CryptocurrencyVM
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public List<QuoteVM> ListQuote { get; set; }
        public double CirculatingSupply { get; set; }
    }
}
