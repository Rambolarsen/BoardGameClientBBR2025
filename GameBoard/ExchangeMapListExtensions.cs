namespace BoardGameClientBBR2025.GameBoard
{
	public static class ExchangeMapListExtensions
	{
		public static ExchangeMap? CurrentExchangeMap(this List<ExchangeMap> exchangeMap, int cropSize)
		{
			foreach (var oneExchangeMap in exchangeMap.OrderBy(x => x.CropSize))
			{
				if (cropSize >= oneExchangeMap.CropSize)
				{
					return oneExchangeMap;
				}
			}

			return null;
		}

		public static ExchangeMap? NextExchangeMap(this List<ExchangeMap> exchangeMap, ExchangeMap? currentExchangeMap)
		{
			if (currentExchangeMap == null)
			{
				return exchangeMap.MinExchangeMap();
			}

			return exchangeMap.Where(x => x.CropSize > currentExchangeMap.CropSize)
				.OrderBy(x => x.CropSize)
				.FirstOrDefault();
		}

		public static ExchangeMap? NextExchangeMap(this List<ExchangeMap> exchangeMap, int cropSize)
		{
			return exchangeMap.NextExchangeMap(exchangeMap.CurrentExchangeMap(cropSize));
		}

		public static ExchangeMap MinExchangeMap(this List<ExchangeMap> exchangeMap)
		{
			return exchangeMap.OrderBy(x => x.CropSize).First();
		}

		public static ExchangeMap MaxExchangeMap(this List<ExchangeMap> exchangeMap)
		{
			return exchangeMap.OrderByDescending(x => x.CropSize).First();
		}
	}
}
