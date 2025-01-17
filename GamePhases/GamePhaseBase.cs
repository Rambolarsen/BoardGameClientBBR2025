using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases
{
	public abstract class GamePhaseBase : IGamePhase
	{
		public abstract GamePhaseEnum GamePhase { get; }

		public string PhaseName => GamePhase.GetStateName();

		public abstract void DoPhase(GameState gameState);
	}
}
