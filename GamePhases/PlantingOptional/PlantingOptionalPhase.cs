using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.PlantingOptional;

public class PlantingOptionalPhase : GamePhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.PlantingOptional;

    protected override async Task PhaseImplementation(string gameName, string ourPlayerId, List<Card> ourHand, Player activePlayer, PlayingClient playingClient)
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

	    await PlantIfSameAlreadyExistsOnField(cards.FirstCardOnHand(), fields, gameName, playerId, playingClient);
    }


    private async Task PlantIfSameAlreadyExistsOnField(Card card, List<Field> fields, string gameName, string playerId, PlayingClient playingClient)
    {
	    var fieldWithSameBeanType = fields.FirstOrDefault(x => x.ContainsSameTypeOfBean(card));

	    if (fieldWithSameBeanType != null)
	    {
		    await fieldWithSameBeanType.PlantBean(card, gameName, playerId, playingClient);
	    }
    }
}