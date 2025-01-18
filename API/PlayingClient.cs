using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace BoardGameClientBBR2025.API
{
    public class PlayingClient
    {
        private readonly HttpClient httpClient;

        public PlayingClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string?> Plant(string gameName, string playerId, string fieldId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.PlayingUrl}/plant?gameName={gameName}&playerId={playerId}&fieldId={fieldId}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        public async Task<string?> EndPlanting(string gameName, string playerId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.PlayingUrl}/end-planting?gameName={gameName}&playerId={playerId}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        public async Task<string?> EndTrading(string gameName, string playerId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.PlayingUrl}/end-trading?gameName={gameName}&playerId={playerId}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        public async Task<string?> TradePlant(string gameName, string playerId, string cardId, string fieldId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.PlayingUrl}/trade-plant?gameName={gameName}&playerId={playerId}&cardId={cardId}&fieldId={fieldId}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        public async Task<string?> HarvestField(string gameName, string playerId, string fieldId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.PlayingUrl}/harvest-field?gameName={gameName}&playerId={playerId}&fieldId={fieldId}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<string>(body);
            }
        }

        public async Task RequestTrade(string gameName, string playerId, RequestTrade requestTrade)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{Constants.GameUrl}/request-trade?gameName={gameName}&playerId={playerId}"),

                Content = new StringContent(JsonSerializer.Serialize(requestTrade))
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }

        public async Task AcceptTrade(string gameName, string playerId, AcceptTrade acceptTrade)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"{Constants.PlayingUrl}/accept-trade?gameName={gameName}&playerId={playerId}"),

                Content = new StringContent(JsonSerializer.Serialize(acceptTrade))
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
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
        [JsonPropertyName("offeredCards")]
        public string[]? OfferedCards { get; set; }

        [JsonPropertyName("cardTypesWanted")]
        public string[]? CardTypesWanted { get; set; }
    }

    public class AcceptTrade
    {
        [JsonPropertyName("negotiationId")]
        public string? NegotiationId { get; set; }

        [JsonPropertyName("payment")]
        public string[]? Payment { get; set; }
    }
}