using System;
namespace CryptocurrencyPrice.Entities.MP.Base
{
    /// <summary>
    /// Base out to return one item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseGetOut<T> : BaseOut
    {
        public T Entity { get; set; }
    }
}
