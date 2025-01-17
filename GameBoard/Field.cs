using System.Text.Json.Serialization;

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

			return Card.First().CoinValue(Card.Count);
		}

		public void PlantBean(Card card)
		{
			if (Card.Any())
			{
				if (Card.First().Type != card.Type)
				{
					//Sell field to server
				}
			}

			//Send plant bean to server
		}
	}
}
