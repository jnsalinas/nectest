using System;
using CryptocurrencyPrice.Api.Filters;
using CryptocurrencyPrice.Business.Interfaces;
using CryptocurrencyPrice.Entities.MP.Base;
using Microsoft.AspNetCore.Mvc;

namespace CryptocurrencyPrice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiKeyAuth]
    public class CryptocurrencyController : ControllerBase
    {

        private readonly ICryptocurrencyBO _iCryptocurrencyBO;

        public CryptocurrencyController(ICryptocurrencyBO iCryptocurrencyBO)
        {
            _iCryptocurrencyBO = iCryptocurrencyBO;
        }

        /// <summary>
        /// Get cryptocurrencies information
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCryptocurrencyQuotes")]
        public IActionResult GetCryptocurrencyQuotes(string cryptocurrencies = "BTC,ETH,BNB,USDT,ADA")
        {
            return new ObjectResult(_iCryptocurrencyBO.GetCryptocurrencyQuotes(cryptocurrencies));
        }

        /// <summary>
        /// Convert value crypto
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPriceConversion")]
        public IActionResult GetPriceConversion(string crypto = "BTC", double amount = 10)
        {
            if (!string.IsNullOrEmpty(crypto) && amount != double.MinValue && amount > double.MinValue)
            {
                return new ObjectResult(_iCryptocurrencyBO.GetPriceConversion(crypto, amount));
            }
            else
            {
                return new ObjectResult(new BaseOut
                {
                    Result = Result.LogicError,
                    Message = "Error with values, please confirim data"
                });
            }
        }

    }
}
