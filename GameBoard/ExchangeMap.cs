using System.Text.Json.Serialization;

namespace BoardGameClientBBR2025.GameBoard
{
	public class ExchangeMap
	{
		[JsonPropertyName("cropSize")]
		public int CropSize { get; set; }

		[JsonPropertyName("value")]
		public int Value { get; set; }
	}
}
