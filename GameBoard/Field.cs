using System.Text.Json.Serialization;

namespace BoardGameClientBBR2025.GameBoard
{
	public class Field
	{
		[JsonPropertyName("key")]
		public Guid Key { get; set; }

		[JsonPropertyName("card")]
		public List<ICard> Card { get; set; }
	}
}
