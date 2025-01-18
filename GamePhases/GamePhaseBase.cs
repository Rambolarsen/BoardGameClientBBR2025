using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases
{
    public abstract class GamePhaseBase : IGamePhase
    {
        public abstract GamePhaseEnum GamePhase { get; }

        public string PhaseName => GamePhase.GetPhaseName();

        public async Task DoPhase(Guid playerId, GameState gameState, PlayingClient playingClient)
        {
	        var activePlayer = gameState.GetActivePlayer();
	        if (activePlayer == null)
	        {
		        return;
	        }
	        
	        await PhaseImplementation(gameState.Name, playerId.ToString(), gameState.YourHand, activePlayer, playingClient);
        }

        protected abstract Task PhaseImplementation(string gameName, string ourPlayerId, List<Card> ourHand, Player activePlayer, PlayingClient playingClient);
    }
}
