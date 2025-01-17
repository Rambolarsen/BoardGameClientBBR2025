using BoardGameClientBBR2025.API;

var client = new HttpClient();
var game = new Game(client);


var gameState = await game.GetGame("GAME1"); //DUMMY SHIT IS FUN!
var playerKey = Guid.NewGuid();
var id = await game.JoinGame("GAME1", playerKey, "mjøndalen");
Console.Write(gameState);

var scoreClient = new ScoreClient(client);
var score = await scoreClient.GetScore();
Console.WriteLine("Score:" + score);
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