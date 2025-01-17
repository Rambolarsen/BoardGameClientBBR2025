using BoardGameClientBBR2025.GameBoard;
using System.Runtime.InteropServices;
using System.Text.Json;
namespace BoardGameClientBBR2025.API
{
    public class ScoreClient
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl = "https://localhost:7046/api/score";


        public ScoreClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IDictionary<string, int>?> GetScore()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/get"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IDictionary<string, int>>(body);
            }
        }
    }
}
