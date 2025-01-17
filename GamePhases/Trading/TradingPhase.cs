using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Trading;

public class TradingPhase : GamePhaseBase, IGamePhase
{
    private readonly PlayingClient _playingClient = new PlayingClient(new HttpClient());

    public override GamePhaseEnum GamePhase => GamePhaseEnum.Trading;

    public override async Task DoPhase(Guid playerId, GameState gameState, PlayingClient playingClient)
    {
        await _playingClient.EndTrading(gameState.Name, gameState.CurrentPlayer);
    }
}