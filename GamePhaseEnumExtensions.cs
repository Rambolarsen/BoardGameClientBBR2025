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

		public static GamePhaseEnum ToGamePhase(this string gamePhaseString)
		{
			switch (gamePhaseString)
			{
				case "Registering":
					return GamePhaseEnum.Registering;
				case "Planting":
					return GamePhaseEnum.Planting;
				case "PlantingOptional":
					return GamePhaseEnum.PlantingOptional;
				case "Trading":
					return GamePhaseEnum.Trading;
				case "TradePlanting":
					return GamePhaseEnum.TradePlanting;
				default:
					throw new Exception($"Could not find a game pahse for {gamePhaseString}");
			}
		}
	}
}
