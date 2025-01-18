using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.TradePlanting;

public class TradePlantingPhase : GamePhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.TradePlanting;

    protected override async Task PhaseImplementation(string gameName, string ourPlayerId, List<Card> ourHand, Player activePlayer, PlayingClient playingClient)
    {
		var cardsToPlant = new List<Card>();
		cardsToPlant.AddRange(activePlayer.DrawnCards);
		cardsToPlant.AddRange(activePlayer.TradedCards);

		foreach (var card in cardsToPlant)
		{
			var validField = GetValidField(card, activePlayer);
			if (validField != null)
			{
				await validField.PlantBean(card, gameName, ourPlayerId, playingClient);
			}
		}
	}

    private static Field? GetValidField(Card card, Player activePlayer)
    {
        var fields = activePlayer.Fields;

        var fieldContainingSameCardType = fields.FirstOrDefault(x => x.ContainsSameTypeOfBean(card));

        if (fieldContainingSameCardType != null)
        {
            return fieldContainingSameCardType;
        }

        var largestField = fields.MaxBy(f => f.Card.Count);

        return largestField;
    }
}