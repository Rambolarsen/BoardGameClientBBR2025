using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;
using System.Text.Json;
namespace BoardGameClientBBR2025.API
{
    public class Playing
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl = "https://localhost:7046/api/playing";


        public Playing(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> Plant(string gameName, string playerId, string fieldId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/plant?gameName={gameName}?playerId={playerId}?fieldId={fieldId}"),
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
                RequestUri = new Uri($"{baseUrl}/end-planting?gameName={gameName}?playerId={playerId}"),
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
                RequestUri = new Uri($"{baseUrl}/end-trading?gameName={gameName}?playerId={playerId}"),
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
                RequestUri = new Uri($"{baseUrl}/trade-plant?gameName={gameName}?playerId={playerId}?cardId={cardId}?fieldId={fieldId}"),
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
                RequestUri = new Uri($"{baseUrl}/harvest-field?gameName={gameName}?playerId={playerId}?fieldId={fieldId}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        public async Task<string> RequestTrade(string gameName, string playerId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{baseUrl}/request-trade?gameName={gameName}?playerId={playerId}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<RequestTrade>(body);
            }
        }

        public async Task<string> AcceptTrade(string gameName, string playerId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{baseUrl}/accept-trade?gameName={gameName}?playerId={playerId}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<AcceptTrade>(body);
            }
        }
        
    }
    public class RequestTrade
    {
        public string[] OfferedCards { get; set; }
        public string[] CardTypesWanted { get; set; }
    }

    public class AcceptTrade
    {
        public string negotiationId { get; set; }
        public string[] payment { get; set; }
    }
}

Trade.OfferedCards
