using System.Text.Json.Serialization;

namespace BoardGameClientBBR2025.GameBoard
{
	public class Player
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("coins")]
		public int Coins { get; set; }

		[JsonPropertyName("fields")]
		public List<Field> Fields { get; set; }

		[JsonPropertyName("hand")]
		public int Hand { get; set; }

		[JsonPropertyName("drawnCards")]
		public List<Card> DrawnCards { get; set; }

		[JsonPropertyName("tradedCards")]
		public List<Card> TradedCards { get; set; }

		[JsonPropertyName("isActive")]
		public bool IsActive { get; set; }
	}
}
