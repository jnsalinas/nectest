using System;
namespace CryptocurrencyPrice.Entities.MP.Base
{
    /// <summary>
    /// when has api error return exception information
    /// </summary>
    public class ExceptionOut: BaseOut
    {
        public string Exception { get; set; }
    }
}
