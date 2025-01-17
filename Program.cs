// See https://aka.ms/new-console-template for more information
using BoardGameClientBBR2025;

Console.WriteLine("Hello, World!");

var client = new HttpClient();
var game = new Game(client);


var state = await game.GetGame();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://localhost:7046/api/game/all"),
};

using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);
    // Test
}