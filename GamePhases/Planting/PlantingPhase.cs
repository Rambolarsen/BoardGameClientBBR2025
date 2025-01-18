using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Planting
{
    public class PlantingPhase : PlantingPhaseBase, IGamePhase
    {
        public override GamePhaseEnum GamePhase => GamePhaseEnum.Planting;

        protected override async Task PhaseImplementation(string gameName, string ourPlayerId, string ourPlayerName, DateTime phaseEnds, List<Card> ourHand, Player activePlayer, Player us, PlayingClient playingClient)
        {
            await playingClient.Plant(gameName, ourPlayerId, activePlayer.Fields.First().Key.ToString());
	        //if (!ourHand.Any())
	        //{
		       // return;
	        //}

	        //await PlantCardOnBestField(ourHand.FirstCardOnHand(), activePlayer.Fields, gameName, ourPlayerId, playingClient);
        }
    }
}
