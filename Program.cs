using BoardGameClientBBR2025;
using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

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

foreach (var game in games)
{
    var playerKey = Guid.NewGuid();
    var playerKey2 = Guid.NewGuid();
    var gameName = game.Name;
    if(game.CurrentState.ToGameState() == GameStateEnum.Registering)
    {
        
        await gameClient.JoinGame(game.Name, playerKey, player1);
        await gameClient.JoinGame(game.Name, playerKey2, player2);


        //await gameClient.Start(game.Name);

        //var updatedGame =  await gameClient.GetGame(game.Name);
        //var scoreClient = new ScoreClient(client);
        //var score = await scoreClient.GetScore();
        //Console.WriteLine("Score:" + score);

        //var playingClient = new PlayingClient(client);
        //var plant = await playingClient.Plant(updatedGame.Name, playerKey.ToString(), updatedGame.Players[0].Fields[0].Key.ToString());

    }
    else if (game.CurrentState.ToGameState() == GameStateEnum.Playing)
    {

    }
    Console.Write(game);
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