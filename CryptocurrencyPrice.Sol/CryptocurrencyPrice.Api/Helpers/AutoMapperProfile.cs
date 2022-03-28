using System;
using AutoMapper;
using CryptocurrencyPrice.Coinmarketcap.Entities.ResponseCoinmarketcap;
using CryptocurrencyPrice.Entities.VM;

namespace CryptocurrencyPrice.Api.Helpers
{
    /// <summary>
    /// Automapper configuration to optmize assign values
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<CryptocurrencyVM, CryptocurrencyResponse>().ReverseMap();
            CreateMap<QuoteVM, QuoteResponse>().ReverseMap();
        }
    }
}