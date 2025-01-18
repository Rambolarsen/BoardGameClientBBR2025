using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases
{
	public abstract class PlantingPhaseBase : GamePhaseBase
	{
		protected async Task PlantCardOnBestField(Card card, List<Field> fields, string gameName, string playerId, PlayingClient playingClient)
		{
			await SellFieldsThatAreMaxedOut(fields, gameName, playerId, playingClient);

			var fieldToPlantOn = FindBestFieldToPlantOn(card, fields);

			await fieldToPlantOn.PlantBean(card, gameName, playerId, playingClient);
		}

		protected Field FindBestFieldToPlantOn(Card card, List<Field> fields)
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

		protected Field FindBestFieldToSell(List<Field> fields)
		{
			return fields.AllowedToHarvest().OrderBy(x => x.Card.Potential()).First();
		}

		protected async Task SellFieldsThatAreMaxedOut(List<Field> fields, string gameName, string playerId, PlayingClient playingClient)
		{
			foreach (var field in fields.Where(x => x.IsMaxCropSize()))
			{
				await field.SellBeans(gameName, playerId, playingClient);
			}
		}

		protected async Task PlantIfSameBeanTypeAlreadyExistsOnField(Card card, List<Field> fields, string gameName, string playerId, PlayingClient playingClient)
		{
			var fieldWithSameBeanType = fields.FirstOrDefault(x => x.ContainsSameTypeOfBean(card));

			if (fieldWithSameBeanType != null)
			{
				await fieldWithSameBeanType.PlantBean(card, gameName, playerId, playingClient);
			}
		}
	}
}
