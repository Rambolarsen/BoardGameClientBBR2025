using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025
{
    public class Agent
    {
        private readonly GameState gameState;
        private readonly Guid playerId;
        private readonly string playerName;
        private bool joined = false;
        private GameClient gameClient;

        public Agent(GameState gameState, 
            Guid playerId, string playerName, 
            GameClient gameClient)
        {
            this.gameState = gameState;
            this.playerId = playerId;
            this.playerName = playerName;
            this.gameClient = gameClient;
        }


        public async Task Start()
        {
            while (true)
            {
                await Run();
                Thread.Sleep(100);
            }
        }
        private async Task Run() 
        {
            if (gameState.CurrentState.ToGameState() == GameStateEnum.Registering)
            {
                if(!joined)
                {
                    joined = await gameClient.JoinGame(gameState.Name, playerId, playerName);
                }//await gameClient.Start(game.Name);

                //var updatedGame =  await gameClient.GetGame(game.Name);
                //var scoreClient = new ScoreClient(client);
                //var score = await scoreClient.GetScore();
                //Console.WriteLine("Score:" + score);

                //var playingClient = new PlayingClient(client);
                //var plant = await playingClient.Plant(updatedGame.Name, playerKey.ToString(), updatedGame.Players[0].Fields[0].Key.ToString());

            }
            else if (gameState.CurrentState.ToGameState() == GameStateEnum.Playing)
            {

            }
        }

    }
}
