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

        foreach (object fakeCard in cardsToPlant)
        {
            var card = ToCard(fakeCard);

            var validField = GetValidField(card, gameState);

            validField.PlantBean(card);
        }
    }

    private static Field GetValidField(Card card, GameState gameState)
    {
        var fields = gameState.Players.First(p => p.Name == gameState.CurrentPlayer).Fields;

        var fieldContainingSameCardType = fields.FirstOrDefault(x => x.ContainsSameTypeOfBean(card));

        if (fieldContainingSameCardType != null)
        {
            return fieldContainingSameCardType;
        }

        var largestField = fields.MaxBy(f => f.Card.Count);

        return largestField;
    }

    private static Card ToCard(object card)
    {
        throw new NotImplementedException();
    }
}