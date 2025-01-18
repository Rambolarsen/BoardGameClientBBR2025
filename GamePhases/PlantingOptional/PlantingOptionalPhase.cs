using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.PlantingOptional;

public class PlantingOptionalPhase : PlantingPhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.PlantingOptional;

    protected override async Task PhaseImplementation(string gameName, string ourPlayerId, string ourPlayerName, List<Card> ourHand, Player activePlayer, Player us, PlayingClient playingClient)
    {
		await PlantIfWeWantTo(ourHand, activePlayer.Fields, gameName, ourPlayerId, playingClient);

		await playingClient.EndPlanting(gameName, ourPlayerId);
	}

    private async Task PlantIfWeWantTo(List<Card> cards, List<Field>? fields, string gameName, string playerId, PlayingClient playingClient)
    {
	    if (fields == null)
	    {
		    return;
	    }

	    if (!cards.Any())
	    {
		    return;
	    }

	    await PlantIfSameBeanTypeAlreadyExistsOnField(cards.FirstCardOnHand(), fields, gameName, playerId, playingClient);
    }
}