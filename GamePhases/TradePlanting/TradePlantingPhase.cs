using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.TradePlanting;

public class TradePlantingPhase : PlantingPhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.TradePlanting;

    protected override async Task PhaseImplementation(string gameName, string ourPlayerId, string ourPlayerName, List<Card> ourHand, Player activePlayer, PlayingClient playingClient)
    {
		var cardsToPlant = new List<Card>();
		cardsToPlant.AddRange(activePlayer.DrawnCards);
		cardsToPlant.AddRange(activePlayer.TradedCards);

		foreach (var card in cardsToPlant)
		{
			var field = FindBestFieldToPlantOn(card, activePlayer.Fields);
			await field.PlantBean(card, gameName, ourPlayerId, playingClient);
		}
	}
}