using ConstructionApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionAppClient
{
    internal class ContractorApiClient
    {
        private static readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7071/") };
        public async Task AssignContractorAsync(Site site,Contractor contractor)

        {
            string convertToJson = System.Text.Json.JsonSerializer.Serialize(site);
            var content = new StringContent(convertToJson, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/contractors", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
