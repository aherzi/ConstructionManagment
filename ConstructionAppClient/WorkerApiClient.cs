using ConstructionApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConstructionAppClient
{
    public class WorkerApiClient
    {

        private readonly HttpClient httpClient;

        public WorkerApiClient(HttpClient httpclient)
        {
            if (httpclient == null)
            {
                throw new ArgumentNullException(nameof(httpclient));
            }

            httpClient = httpclient;
            httpClient.BaseAddress = new Uri("https://localhost:7071/");
        }

        public async Task<List<Worker>> GetWorkersAsync()
        {
            var response = await httpClient.GetAsync("api/workers");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            List<Worker> workers =
                JsonSerializer.Deserialize<List<Worker>>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return workers;
        }

    }
}
