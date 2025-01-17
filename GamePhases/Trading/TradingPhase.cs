using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Trading;

public class TradingPhase : GamePhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.Trading;

    public override async Task DoPhase(GameState gameState, PlayingClient playingClient)
    {
        await playingClient.EndTrading(gameState.Name, gameState.CurrentPlayer);
    }
}