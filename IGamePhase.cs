using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025
{
    public interface IGamePhase
    {
        GamePhaseEnum GamePhase { get; }
        string PhaseName { get; }
        Task DoPhase(Guid playerId, string playerName, GameState gameState, PlayingClient playingClient);
    }
}
