using BoardGameClientBBR2025;
using BoardGameClientBBR2025.API;

var client = new HttpClient();
var gameClient = new GameClient(client);
var playingClient = new PlayingClient(client);
const string player1 = "Mjondalen";
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

//var game = games.ElementAt(1);
foreach (var game in games)
{
    agents.Add(new Agent(game, playerKey1, player1, gameClient, playingClient));
    //agents.Add(new Agent(game, playerKey2, player2, gameClient, playingClient));
}

var agentTasks = agents.Select(agent => Task.Run(() => agent.Start())).ToArray();
await Task.WhenAll(agentTasks);


Console.WriteLine("Press any key to exit...");
Console.ReadKey();