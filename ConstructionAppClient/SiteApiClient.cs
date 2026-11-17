using ConstructionApp.Shared;
using ConstructionAppClient;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConstructionAppClient
{
    public class SiteApiClient
    {
        private static readonly HttpClient   _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7071/") };
        
        public async Task CreateSiteAsync(Site site)
            
        {
            string convertToJson = System.Text.Json.JsonSerializer.Serialize(site);
            var content = new StringContent(convertToJson, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/sites", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
