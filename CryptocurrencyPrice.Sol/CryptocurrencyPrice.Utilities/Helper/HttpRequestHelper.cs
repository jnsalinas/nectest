using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CryptocurrencyPrice.Utilities.Helper
{
    public static class HttpRequestHelper
    {
        /// <summary>
        /// generic method to consume get request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<T> GetRequest<T>(string uri, Dictionary<string, string> headers = null)
        {
            T result = default(T);

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (headers != null && headers.Any())
                    {
                        foreach (var item in headers)
                        {
                            client.DefaultRequestHeaders.Add(item.Key, item.Value);
                        }
                    }

                    using (HttpResponseMessage response = await client.GetAsync(uri))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("result");
                        Console.WriteLine(responseBody);
                        return JsonConvert.DeserializeObject<T>(responseBody, new ExpandoObjectConverter());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return result;
            }
        }

    }
}
