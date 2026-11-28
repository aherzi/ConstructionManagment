using ConstructionApp.Shared;
using ConstructionAppClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConstructionAppClient
{
    public class SiteApiClient
    {
        
        private static readonly HttpClient   _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7071/") };
        
        public async Task<List<Owner>> GetOwnersAsync()
        {
            using (var response = await _httpClient.GetAsync("api/owners"))
            {
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                List<Owner> owners = System.Text.Json.JsonSerializer.Deserialize<List<Owner>>(
                    json,
                    new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (owners == null)
                    return new List<Owner>();
                return owners;
            }
        }

        public async Task CreateSiteAsync(Site site)
            
        {
            string convertToJson = System.Text.Json.JsonSerializer.Serialize(site);
            var content = new StringContent(convertToJson, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/sites", content);
            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new InvalidOperationException($"Site creation failed ({(int)response.StatusCode}): {error}");
            }
            var savedSite = System.Text.Json.JsonSerializer.Deserialize<Site>(
                await response.Content.ReadAsStringAsync(),
                new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (savedSite == null || savedSite.SiteID <= 0)
                throw new InvalidOperationException("The server did not return a saved site ID.");
            site.SiteID = savedSite.SiteID;
        }
        public async Task<List<Site>> GetContractorSitesAsync(int contractorId)
        {
            var response = await _httpClient.GetAsync(
                $"api/sites/contractor/{contractorId}");

            string json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                string message = json;
                try
                {
                    using (var problem = System.Text.Json.JsonDocument.Parse(json))
                    {
                        System.Text.Json.JsonElement detail;
                        if (problem.RootElement.TryGetProperty("detail", out detail))
                            message = detail.GetString();
                    }
                }
                catch (System.Text.Json.JsonException) { }
                throw new InvalidOperationException($"Could not load sites ({(int)response.StatusCode}): {message}");
            }

            List<Site> sites =
                System.Text.Json.JsonSerializer.Deserialize<List<Site>>(
                    json,
                    new System.Text.Json.JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return sites ?? new List<Site>();
        }
    }
}
