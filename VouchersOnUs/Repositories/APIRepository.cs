using System;
using System.Text.Json;
using Newtonsoft.Json;
using VouchersOnUs.API.DTO;
using VouchersOnUs.API.Interfaces;

namespace VouchersOnUs.API.Repositories
{
    public class APIRepository<T> : IAPIRepository<T> where T : Type
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiPath;

        public APIRepository(HttpClient httpClient, string apiPath)
        {
            _httpClient = httpClient;
            _apiPath = apiPath;
        }

        //Testing logic for generic API calls
        public T Get(string value)
        {
            _httpClient.BaseAddress = new Uri(_apiPath);
            var result = _httpClient.GetAsync(value).Result;
            result.EnsureSuccessStatusCode();
            string resultContentString = result.Content.ReadAsStringAsync().Result;
            T resultContent = JsonConvert.DeserializeObject<T>(resultContentString);

            return resultContent;


        }
    }
}
