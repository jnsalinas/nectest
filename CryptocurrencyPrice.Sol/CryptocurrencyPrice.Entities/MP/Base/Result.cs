using System;
namespace CryptocurrencyPrice.Entities.MP.Base
{
    /// <summary>
    /// enum to manage api errors
    /// </summary>
    public enum Result
    {
        Success,
        Error,
        GenericError,
        InvalidApiKey,
        LogicError
    }
}
