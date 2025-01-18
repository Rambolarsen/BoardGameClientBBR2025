using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;
using BoardGameClientBBR2025.GamePhases.Planting;
using BoardGameClientBBR2025.GamePhases.PlantingOptional;
using BoardGameClientBBR2025.GamePhases.TradePlanting;
using BoardGameClientBBR2025.GamePhases.Trading;

namespace BoardGameClientBBR2025
{
    public class Agent
    {
        private GameState gameState;
        private readonly Guid playerId;
        private readonly string playerName;
        private bool joined = false;
        private GameClient gameClient;
        private readonly PlayingClient playingClient;
        private PlantingOptionalPhase plantingOptionalPhase;
        private PlantingPhase plantingPhase;
        private TradingPhase tradingPhase;
        private TradePlantingPhase tradePlantingPhase;

        public Agent(GameState gameState, 
            Guid playerId, string playerName, 
            GameClient gameClient,
            PlayingClient playingClient)
        {
            this.gameState = gameState;
            this.playerId = playerId;
            this.playerName = playerName;
            this.gameClient = gameClient;
            this.playingClient = playingClient;
            plantingOptionalPhase = new PlantingOptionalPhase();
            plantingPhase = new PlantingPhase();
            tradingPhase = new TradingPhase();
            tradePlantingPhase = new TradePlantingPhase();
        }


        public async Task Start()
        {
            Console.WriteLine($"Starting agent Name:{playerName}, Id: {playerId} for game {gameState.Name}");

            while (true)
            {
                await Run();
                Thread.Sleep(1000);
            }
        }
        private async Task Run() 
        {
            gameState = await gameClient.GetGame(gameState.Name);
            if (gameState.CurrentState.ToGameState() == GameStateEnum.Registering)
            {
                if(!gameState.Players.Any(x => x.Name == playerName))
                {
                    if(await gameClient.JoinGame(gameState.Name, playerId, playerName))
                    {
                        Console.WriteLine($"Registered!. Game name: {gameState.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"Unable to register game. Game name: {gameState.Name}. Will retry shortly.");
                    }
                }
                else
                {
                    Console.WriteLine($"Waiting for Game start: {gameState.Name}");
                }

            }
            else if (gameState.CurrentState.ToGameState() == GameStateEnum.Playing)
            {
                Console.WriteLine($"Playing Game! Current state: {GameStateEnum.Playing}. Game name: {gameState.Name}");

                if (gameState.CurrentPlayer.Equals(playerName)) 
                {
                    //vår tur! Gjør noe
                    switch (gameState.CurrentPhase.ToGamePhase())
                    {
                        case GamePhaseEnum.Planting:
                            await Runner(plantingPhase.DoPhase(playerId, gameState, playingClient), GamePhaseEnum.Planting);
                            break;
                        case GamePhaseEnum.PlantingOptional:
                            await Runner(plantingOptionalPhase.DoPhase(playerId, gameState, playingClient), GamePhaseEnum.PlantingOptional);
                            break;
                        case GamePhaseEnum.Trading:
                            await Runner(tradingPhase.DoPhase(playerId, gameState, playingClient), GamePhaseEnum.Trading);
                            break;
                        case GamePhaseEnum.TradePlanting:
                            await Runner(tradePlantingPhase.DoPhase(playerId, gameState, playingClient), GamePhaseEnum.TradePlanting);
                            break;
                    }
                }
            }
        }

        private async Task Runner(Task taskToRun, GamePhaseEnum gamePhaseEnum)
        {
            Console.WriteLine($"Playing Game! Current Phase: {gamePhaseEnum}. Game name: {gameState.Name}");
            try
            {
                await taskToRun;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GamePhase: {ex}");
            }
        }

    }
}
