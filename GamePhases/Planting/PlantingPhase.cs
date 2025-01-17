using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Planting
{
	public class PlantingPhase : GamePhaseBase, IGamePhase
	{
		public override GamePhaseEnum GamePhase => GamePhaseEnum.Planting;
		
		public override void DoPhase(GameState gameState)
		{
			throw new NotImplementedException();
		}
	}
}
