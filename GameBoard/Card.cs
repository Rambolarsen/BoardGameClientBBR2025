using System.Text.Json.Serialization;

namespace BoardGameClientBBR2025.GameBoard
{
	public class Card
	{
		[JsonPropertyName("id")]
		public Guid Id { get; set; }

		[JsonPropertyName("type")]
		public string Type { get; set; } = string.Empty;

		[JsonPropertyName("exchangeMap")]
		public List<ExchangeMap> ExchangeMap { get; set; } = [];

		[JsonPropertyName("firstCard")]
		public bool FirstCard { get; set; }

		public Card() { }

		protected Card(Card copy)
		{
			Id = copy.Id;
			Type = copy.Type;
			ExchangeMap = copy.ExchangeMap;
			FirstCard = copy.FirstCard;
		}
	}
}
