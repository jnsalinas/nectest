using System;
namespace CryptocurrencyPrice.Entities.MP.Base
{
    /// <summary>
    /// Base out, this data is all result api methods
    /// </summary>
    public class BaseOut
    {
        public BaseOut()
        {
            this.Result = Result.Success;
        }
        public Result Result { get; set; }
        public string Message { get; set; }
    }
}
