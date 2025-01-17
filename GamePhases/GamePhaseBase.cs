﻿using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases
{
    public abstract class GamePhaseBase : IGamePhase
    {
        public abstract GamePhaseEnum GamePhase { get; }

        public string PhaseName => GamePhase.GetPhaseName();

        public abstract Task DoPhase(Guid playerId, GameState gameState, PlayingClient playingClient);
    }
}
