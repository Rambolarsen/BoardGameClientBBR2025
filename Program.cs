using BoardGameClientBBR2025.API;

var client = new HttpClient();
var game = new Game(client);
//string[] gameNames = ["GAME1", "GAME2", "GAME3", "GAME4"];
//foreach (var game in gameNames)
//{
//    var gameState = await game.GetGame("GAME3"); //DUMMY SHIT IS FUN!

//}
var gameState = await game.GetGame("GAME3"); //DUMMY SHIT IS FUN!
if(gameState.CurrentPhase == "")
{

}
var playerKey = Guid.NewGuid();
var playerKey2 = Guid.NewGuid();
await game.JoinGame("GAME3", playerKey, "mjøndalen");
await game.JoinGame("GAME2", playerKey2, "mjøndalen2");
Console.Write(gameState);

await game.Start("GAME1");
var scoreClient = new ScoreClient(client);
var score = await scoreClient.GetScore();
Console.WriteLine("Score:" + score);

var playingClient = new PlayingClient(client);
var plant = await playingClient.Plant("GAME1", playerKey.ToString(), gameState.Players[0].Fields[0].Key.ToString());
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