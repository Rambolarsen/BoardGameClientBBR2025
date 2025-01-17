using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Trading;

public class PlantingOptionalPhase : GamePhaseBase, IGamePhase
{
    private readonly PlayingClient _playingClient = new PlayingClient(new HttpClient());

    public override GamePhaseEnum GamePhase => GamePhaseEnum.PlantingOptional;

    public override async Task DoPhase(GameState gameState)
    {
        await _playingClient.EndPlanting(gameState.Name, gameState.CurrentPlayer);
    }
}