using BoardGameClientBBR2025.GameBoard;
using System.Text.Json;
namespace BoardGameClientBBR2025.API
{
    public class GameClient
    {
        private readonly HttpClient httpClient;


        public GameClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<GameState?> GetGame(string gameName, Guid playerId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.GameUrl}?gameName={gameName}&playerId={playerId}"),
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
                RequestUri = new Uri($"{Constants.GameUrl}/all"),
            };

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ICollection<GameState>>(body);

        }

        public async Task<bool> JoinGame(string gameName, Guid playerKey, string name)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.GameUrl}/join?gameName={gameName}&playerKey={playerKey}&name={name}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                return response.IsSuccessStatusCode;
            }
        }

        public async Task Start(string gameName)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{Constants.GameUrl}/start?gameName={gameName}"),
            };

            using (var response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
