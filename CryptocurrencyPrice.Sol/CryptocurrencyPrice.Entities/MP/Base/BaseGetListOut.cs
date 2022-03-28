using System;
using System.Collections.Generic;

namespace CryptocurrencyPrice.Entities.MP.Base
{
    /// <summary>
    /// Base return list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseGetListOut<T> : BaseOut
    {
        public List<T> ListResult { get; set; }
    }
}
