using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Trading;

public class PlantingOptionalPhase : GamePhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.PlantingOptional;

    public override async Task DoPhase(GameState gameState, PlayingClient playingClient)
    {
        await playingClient.EndPlanting(gameState.Name, gameState.CurrentPlayer);
    }
}