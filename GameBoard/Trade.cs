using System.Text.Json.Serialization;

namespace BoardGameClientBBR2025.GameBoard
{
	public class Trade
	{
		[JsonPropertyName("initiatorId")]
		public Guid InitiatorId { get; set; }

		[JsonPropertyName("negotiationId")]
		public Guid NegotiationId { get; set; }

		[JsonPropertyName("offeredCards")]
		public List<string> OfferedCards { get; set; }

		[JsonPropertyName("cardTypesWanted")]
		public List<string> CardTypesWanted { get; set; }
	}
}
