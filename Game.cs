using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BoardGameClientBBR2025
{
    public class Game
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl = "https://localhost:7046/api/game";


        public Game(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<GameState?> GetGame()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/all"),
            };

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<GameState>>(body)?.FirstOrDefault();
            
        }
    }
}
