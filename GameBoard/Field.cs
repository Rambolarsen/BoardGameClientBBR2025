using System.Text.Json.Serialization;
using BoardGameClientBBR2025.API;

namespace BoardGameClientBBR2025.GameBoard
{
	public class Field
	{
		[JsonPropertyName("key")]
		public Guid Key { get; set; }

		[JsonPropertyName("card")]
		public List<Card> Card { get; set; }

		public int CoinValue()
		{
			if (!Card.Any())
			{
				return 0;
			}

			return Card.CoinValue();
		}

		public async Task PlantBean(Card card, string gameName, string playerId, PlayingClient playingClient)
		{
			if (Card.Any())
			{
				if (Card.First().Type != card.Type)
				{
					await SellBeans(gameName, playerId, playingClient);
				}
			}

			await playingClient.Plant(gameName, playerId, Key.ToString());
		}

		public async Task SellBeans(string gameName, string playerId, PlayingClient playingClient)
		{
			await playingClient.HarvestField(gameName, playerId, Key.ToString());
		}

		public bool ContainsSameTypeOfBean(Card card)
		{
			if (!Card.Any())
			{
				return false;
			}

			return Card.First().Type == card.Type;
		}

		public bool IsEmpty()
		{
			return !Card.Any();
		}

		public bool IsMaxCropSize()
		{
			if (IsEmpty())
			{
				return false;
			}

			return Card.IsMaxCropSize();
		}
	}
}
