namespace BoardGameClientBBR2025
{
	public static class GamePhaseEnumExtensions
	{
		public static string GetStateName(this GamePhaseEnum gamePhase)
		{
			switch (gamePhase)
			{
				case GamePhaseEnum.Registering:
					return "Registering";
				case GamePhaseEnum.Planting:
					return "Planting";
				case GamePhaseEnum.PlantingOptional:
					return "PlantingOptional";
				case GamePhaseEnum.Trading:
					return "Trading";
				case GamePhaseEnum.TradePlanting:
					return "TradePlanting";
				default:
					return string.Empty;
			}
		}
	}
}
