using System.Text.Json.Serialization;

namespace BoardGameClientBBR2025.GameBoard
{
	public interface ICard
	{
		[JsonPropertyName("id")]
		public Guid Id { get; set; }

		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("exchangeMap")]
		public List<ExchangeMap> ExchangeMap { get; set; }

		[JsonPropertyName("firstCard")]
		public bool FirstCard { get; set; }
	}
}
