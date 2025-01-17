using BoardGameClientBBR2025.API;

namespace BoardGameClientBBR2025.GameBoard
{
	public static class FieldExtensions
	{
		public static void SellMaxedOutFields(this List<Field> fields, string gameName, Guid playerId, PlayingClient playingClient)
		{
			foreach (var field in fields.Where(x => x.IsMaxedOut()))
			{
				field.SellBeans(gameName, playerId, playingClient);
			}
		}
	}
}
