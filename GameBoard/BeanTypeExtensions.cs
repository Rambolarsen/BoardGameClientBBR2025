namespace BoardGameClientBBR2025.GameBoard
{
	public static class BeanTypeExtensions
	{
		public static string ToTypeString(this BeanType bean)
		{
			switch (bean)
			{
				case BeanType.GardenBean:
					return "GardenBean";
				case BeanType.BlackEyedBean:
					return "BlackEyedBean";
				case BeanType.StinkBean:
					return "StinkBean";
				case BeanType.BlueBean:
					return "BlueBean";
				case BeanType.GreenBean:
					return "GreenBean";
				case BeanType.RedBean:
					return "RedBean";
				case BeanType.ChiliBean:
					return "ChiliBean";
				case BeanType.SoyBean:
					return "SoyBean";
				default:
					throw new Exception($"Could not find a card for card {bean}");
			}
		}

		public static BeanType ToBeanType(this string cardString)
		{
			switch (cardString)
			{
				case "GardenBean":
					return BeanType.GardenBean;
				case "BlackEyedBean":
					return BeanType.BlackEyedBean;
				case "StinkBean":
					return BeanType.StinkBean;
				case "BlueBean":
					return BeanType.BlueBean;
				case "GreenBean":
					return BeanType.GreenBean;
				case "RedBean":
					return BeanType.RedBean;
				case "ChiliBean":
					return BeanType.ChiliBean;
				case "SoyBean":
					return BeanType.SoyBean;
				default:
					throw new Exception($"Could not find a Bean for card {cardString}");
			}
		}
	}
}
