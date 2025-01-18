using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;
using System.Collections.Generic;

namespace BoardGameClientBBR2025.GamePhases.Planting
{
    public class PlantingPhase : GamePhaseBase, IGamePhase
    {
        public override GamePhaseEnum GamePhase => GamePhaseEnum.Planting;

        public override async Task DoPhase(Guid playerId, GameState gameState, PlayingClient playingClient)
        {
            await PlantCards(gameState.YourHand, gameState.Players.GetActivePlayer()?.Fields, gameState.Name, playerId, playingClient);
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
			await SellFieldsThatAreMaxedOut(fields, gameName, playerId, playingClient);

			var fieldToPlantOn = FindBestFieldToPlantOn(card, fields);

			await fieldToPlantOn.PlantBean(card, gameName, playerId, playingClient);
		}

		private async Task SellFieldsThatAreMaxedOut(List<Field> fields, string gameName, Guid playerId, PlayingClient playingClient)
		{
			foreach (var field in fields.Where(x => x.IsMaxCropSize()))
			{
				await field.SellBeans(gameName, playerId, playingClient);
			}
		}

		private Field FindBestFieldToPlantOn(Card card, List<Field> fields)
		{
			var fieldToPlantOn = fields.FirstOrDefault(x => x.ContainsSameTypeOfBean(card));

			if (fieldToPlantOn != null)
			{
				return fieldToPlantOn;
			}

			fieldToPlantOn = fields.FirstOrDefault(x => x.IsEmpty());

			if (fieldToPlantOn != null)
			{
				return fieldToPlantOn;
			}

			return FindBestFieldToSell(fields);
		}

		private Field FindBestFieldToSell(List<Field> fields)
		{
			return fields.AllowedToHarvest().OrderBy(x => x.Card.Potential()).First();
		}
    }
}
