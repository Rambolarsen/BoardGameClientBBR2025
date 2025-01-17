using BoardGameClientBBR2025.GameBoard;
using System.Text.Json;
namespace BoardGameClientBBR2025.API
{
    public class Playing
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl = "https://localhost:5186/api/playing";


        public Playing(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> Plant(string gameName, string playerId, string fieldId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/plant"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        public async Task<string> EndPlanting(string gameName, string playerId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/end-planting"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        public async Task<string> EndTrading(string gameName, string playerId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/end-trading"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        public async Task<string> TradePlant(string gameName, string playerId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/end-trading"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        public async Task<string> TradePlant(string gameName, string playerId, string cardId, string fieldId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/trade-plant"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

         public async Task<string> HarvestField(string gameName, string playerId, string fieldId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/trade-plant"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

         public async Task<string> RequestTrade(string gameName, string playerId, string cardId, string fieldId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{baseUrl}/request-trade"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        
    }
}
