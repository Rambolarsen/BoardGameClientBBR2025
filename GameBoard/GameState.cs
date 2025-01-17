using System.Text.Json.Serialization;

namespace BoardGameClientBBR2025.GameBoard
{
	public class GameState
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("currentPlayer")]
		public string CurrentPlayer { get; set; }

		[JsonPropertyName("currentPhase")]
		public string CurrentPhase { get; set; }

		[JsonPropertyName("currentState")]
		public string CurrentState { get; set; }

		[JsonPropertyName("round")]
		public int Round { get; set; }

		[JsonPropertyName("phaseTimeLeft")]
		public string PhaseTimeLeft { get; set; }

		[JsonPropertyName("phaseEndTimestamp")]
		public DateTime PhaseEndTimestamp { get; set; }

		[JsonPropertyName("lastStateChange")]
		public DateTime LastStateChange { get; set; }

		[JsonPropertyName("deck")]
		public int Deck { get; set; }

		[JsonPropertyName("availableTrades")]
		public List<Trade> AvailableTrades { get; set; }

		[JsonPropertyName("discardPile")]
		public List<Card> DiscardPile { get; set; }

		[JsonPropertyName("players")]
		public List<Player> Players { get; set; }

		[JsonPropertyName("yourHand")]
		public List<Card> YourHand { get; set; }
	}
}
