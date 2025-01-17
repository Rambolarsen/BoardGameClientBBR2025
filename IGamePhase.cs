using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025
{
	public interface IGamePhase
	{
		GamePhaseEnum GamePhase { get; }
		string PhaseName { get; }
		void DoPhase(GameState gameState);
	}
}
