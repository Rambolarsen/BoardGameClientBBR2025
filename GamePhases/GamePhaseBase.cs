using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases
{
    public abstract class GamePhaseBase : IGamePhase
    {
        public abstract GamePhaseEnum GamePhase { get; }

        public string PhaseName => GamePhase.GetPhaseName();

        public async Task DoPhase(Guid playerId, string playerName, GameState gameState, PlayingClient playingClient)
        {
	        var activePlayer = gameState.GetActivePlayer();
	        if (activePlayer == null)
	        {
		        return;
	        }
	        
	        await PhaseImplementation(gameState.Name, playerId.ToString(), playerName, gameState.PhaseEndTimestamp, gameState.YourHand, activePlayer, gameState.GetUs(playerName), playingClient);

	        await Task.Delay(100);
        }

        protected abstract Task PhaseImplementation(string gameName, string ourPlayerId, string ourPlayerName, DateTime phaseEnds, List<Card> ourHand, Player activePlayer, Player us, PlayingClient playingClient);
    }
}
