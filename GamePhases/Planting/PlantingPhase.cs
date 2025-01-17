using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Planting
{
    public class PlantingPhase : GamePhaseBase, IGamePhase
    {
        public override GamePhaseEnum GamePhase => GamePhaseEnum.Planting;

        public override async Task DoPhase(GameState gameState, PlayingClient playingClient)
        {
            await PlantCards(gameState.YourHand, gameState.Players.GetActivePlayer()?.Fields, gameState.Name, Guid.Empty, playingClient);
        }

		private async Task PlantCards(List<Card> cards, List<Field>? fields, string gameName, Guid playerId, PlayingClient playingClient)
		{
			if (fields == null)
			{
				return;
			}

			if (!cards.Any())
			{
				return;
			}

			await PlantCard(cards.First(x => x.FirstCard), fields, gameName, playerId, playingClient);
		}

		private async Task PlantCard(Card card, List<Field> fields, string gameName, Guid playerId, PlayingClient playingClient)
		{
			var fieldContainingSameCardType = fields.FirstOrDefault(x => x.ContainsSameTypeOfBean(card));
			
			if (fieldContainingSameCardType != null)
			{
				await fieldContainingSameCardType.PlantBean(card, gameName, playerId, playingClient);
				return;
			}

			var emptyField = fields.FirstOrDefault(x => x.IsEmpty());

			if (emptyField != null)
			{
				await emptyField.PlantBean(card, gameName, playerId, playingClient);
				return;
			}

			await fields.First().PlantBean(card, gameName, playerId, playingClient);
		}
	}
}
