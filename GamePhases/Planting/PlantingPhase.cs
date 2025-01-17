using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Planting
{
    public class PlantingPhase : GamePhaseBase, IGamePhase
    {
        public override GamePhaseEnum GamePhase => GamePhaseEnum.Planting;

        public override async Task DoPhase(GameState gameState, PlayingClient playingClient)
        {
            PlantCards(gameState.YourHand, gameState.Players.GetActivePlayer()?.Fields);
        }

		private void PlantCards(List<Card> cards, List<Field>? fields)
		{
			if (fields == null)
			{
				return;
			}

			if (!cards.Any())
			{
				return;
			}

			PlantCard(cards.First(x => x.FirstCard), fields);

			//End planting phase to server
		}

		private void PlantCard(Card card, List<Field> fields)
		{
			var fieldContainingSameCardType = fields.FirstOrDefault(x => x.ContainsSameTypeOfBean(card));
			
			if (fieldContainingSameCardType != null)
			{
				fieldContainingSameCardType.PlantBean(card);
				return;
			}

			var emptyField = fields.FirstOrDefault(x => x.IsEmpty());

			if (emptyField != null)
			{
				emptyField.PlantBean(card);
				return;
			}

			fields.First().PlantBean(card);
		}
	}
}
