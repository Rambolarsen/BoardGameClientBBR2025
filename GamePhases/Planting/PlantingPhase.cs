using System.Security.Cryptography;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Planting
{
	public class PlantingPhase : GamePhaseBase, IGamePhase
	{
		public override GamePhaseEnum GamePhase => GamePhaseEnum.Planting;
		
		public override void DoPhase(GameState gameState)
		{
			PlantCards(gameState.YourHand, gameState.Players.GetActivePlayer()?.Fields);
		}

		private void PlantCards(List<ICard> cards, List<Field>? fields)
		{
			//if (cards == null || fields == null)
			//{
			//	return;
			//}

			//if (cards.Count <= 0)
			//{
			//	return;
			//}

			//PlantCard(cards.First(), fields);

			//foreach (var field in fields)
			//{
			//	if (fields.Any(f => f.Card.Any(c => c.Type == ))
			//}
		}

		private void PlantCard(ICard card, List<Field> fields)
		{
			//foreach (var field in fields)
			//{
			//	if (field.Card.Any(x => x.Type == card.Type))
			//	{
			//		//Add card to field;
			//		break;
			//	}
			//}
		}
	}
}
