using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.TradePlanting;

public class TradePlantingPhase : GamePhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.TradePlanting;

    public override async Task DoPhase(GameState gameState, PlayingClient playingClient)
    {
        var player = gameState.Players.First(p => p.Name == gameState.CurrentPlayer);

        var cardsToPlant = new List<object>();
        cardsToPlant.AddRange(player.DrawnCards);
        cardsToPlant.AddRange(player.TradedCards);

        var firstFieldId = player.Fields.First().Key.ToString();

        foreach (object card in cardsToPlant)
        {
            playingClient.TradePlant(gameState.Name, gameState.CurrentPlayer, GetCardId(card), firstFieldId);
        }
    }

    private string GetCardId(object card)
    {
        throw new NotImplementedException();
    }
}