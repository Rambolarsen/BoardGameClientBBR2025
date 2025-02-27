﻿namespace BoardGameClientBBR2025
{
    public static class GameStateEnumExtensions
    {
        public static string GetStateName(this GameStateEnum gameState)
        {
            switch(gameState)
            {
                case GameStateEnum.Registering:
                    return "Registering";
                case GameStateEnum.Playing:
                    return "Playing";
                case GameStateEnum.GameDone:
                    return "GameDone";
                default:
                    throw new Exception($"Could not find a game state for {gameState}");
            }
        }

        public static GameStateEnum ToGameState(this string gameStateEnum)
        {
            switch(gameStateEnum)
            {
                case "Registering":
                    return GameStateEnum.Registering;
                case "Playing":
                    return GameStateEnum.Playing;
                case "GameDome":
                    return GameStateEnum.GameDone;
                default:
                    throw new Exception($"Could not find a game state for {gameStateEnum}");
            }
        }
    }
}
