using MauiApp1.LR4.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MauiApp1.LR4.Services
{
    public class RateService : IRateService
    {

        public HttpClient _httpClient;

        public RateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Rate>> GetRates(DateTime date)
        {
            var list = new List<int> { 456, 451, 431, 426, 462, 429 };
            List<Rate> rates = new List<Rate>();
            foreach (var item in list)
            {
                var rate = await _httpClient.GetAsync($"{_httpClient.BaseAddress}{item}?ondate=" + date.Date.ToString("yyyy-MM-dd"));
                string content = await rate.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<Rate>(content);
                rates.Add(val);
            }
            return rates;
        }
    }
}
