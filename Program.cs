using BoardGameClientBBR2025;
using BoardGameClientBBR2025.API;

var client = new HttpClient();
var gameClient = new GameClient(client);
const string player1 = "Mjøndalen";
const string player2 = "Mjøndalen2";

var games = await gameClient.GetAllGames();
if(games == null)
{
    Console.WriteLine("No games found");
    return;
}

var agents = new List<Agent>();
var playerKey1 = Guid.NewGuid();

var playerKey2 = Guid.NewGuid();

foreach (var game in games)
{
    agents.Add(new Agent(game, playerKey1, player1, gameClient));
    agents.Add(new Agent(game, playerKey2, player2, gameClient));
    var gameName = game.Name;
    
    Console.Write(game);
}


foreach (var agent in agents)
{
    agent.Start();
}



//var state = await game.GetGame();
//var request = new HttpRequestMessage
//{
//    Method = HttpMethod.Get,
//    RequestUri = new Uri("https://localhost:7046/api/game/all"),
//};

//using (var response = await client.SendAsync(request))
//{
//    response.EnsureSuccessStatusCode();
//    var body = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(body);
//}