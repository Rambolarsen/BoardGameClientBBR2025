using BoardGameClientBBR2025.GameBoard;
using System.Net;
using System.Text.Json;
namespace BoardGameClientBBR2025.API
{
    public class Game
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl = "https://localhost:7046/api/game";


        public Game(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<GameState?> GetGame(string gameName)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}?gameName={gameName}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<GameState>(body);
            }
        }

        public async Task<ICollection<GameState>?> GetAllGames()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/all"),
            };

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ICollection<GameState>>(body);

        }

        public async Task<Guid> JoinGame(string gameName, Guid playerKey, string name)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{baseUrl}/join?gameName={gameName}&playerKey={playerKey}&name={name}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                if (response.StatusCode == HttpStatusCode.BadRequest)
                    return playerKey;

                var body = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Guid>(body);
            }
        }

        // NOT WORKING GIVES 405. FORBIDDEN. WHY CANT WE START GAME? WHYYYYYY
        //public async Task Start(string gameName)
        //{
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Post,
        //        RequestUri = new Uri($"{baseUrl}/start?gameName={gameName}"),
        //    };

        //    using (var response = await httpClient.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //    }
        //}
    }
}
