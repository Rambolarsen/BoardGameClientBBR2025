using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Trading;

public class TradingPhase : GamePhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.Trading;

    protected override async Task PhaseImplementation(string gameName, string ourPlayerId, List<Card> ourHand, Player activePlayer, PlayingClient playingClient)
    {
		await playingClient.EndTrading(gameName, ourPlayerId);
	}
}