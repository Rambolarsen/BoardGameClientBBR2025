namespace BoardGameClientBBR2025.GameBoard
{
	public static class CardListExtensions
	{
		public static bool AllCardsAreOfSameType(this List<Card> cards)
		{
			if (!cards.Any())
			{
				return true;
			}

			var firstCard = cards.First();

			return cards.All(x => x.Type == firstCard.Type);
		}
		
		public static int CoinValue(this List<Card> cards)
		{
			if (!cards.Any())
			{
				return 0;
			}

			if (!cards.AllCardsAreOfSameType())
			{
				return 0;
			}

			var firstCard = cards.First();

			foreach (var oneExchangeValue in firstCard.ExchangeMap.OrderBy(x => x.CropSize))
			{
				if (cards.Count >= oneExchangeValue.CropSize)
				{
					return oneExchangeValue.Value;
				}
			}

			return 0;
		}

		public static bool IsMaxCropSize(this List<Card> cards)
		{
			if (!cards.Any())
			{
				return false;
			}

			if (!cards.AllCardsAreOfSameType())
			{
				return false;
			}

			var firstCard = cards.First();

			return cards.Count >= firstCard.ExchangeMap.Max(x => x.CropSize);
		}

		public static int Potential(this List<Card> cards)
		{
			if (!cards.Any())
			{
				return 100;
			}

			if (cards.IsMaxCropSize())
			{
				return 0;
			}

			var numberOfCardsToNextCoinIncrease = cards.NumberOfCardsToNextCoinIncrease();

			return 0;
		}

		public static int NumberOfCardsToNextCoinIncrease(this List<Card> cards)
		{
			if (!cards.Any())
			{
				//A nice value?
				return 1;
			}
			
			if (cards.IsMaxCropSize())
			{
				//Return "infinite"
				return 100;
			}

			var currentCropSize = cards.Count;
			var firstCard = cards.First();

			var nextCropSize = firstCard.ExchangeMap
				.Where(x => x.CropSize > currentCropSize)
				.OrderBy(x => x.CropSize)
				.First()
				.CropSize;

			return nextCropSize - currentCropSize;

			return 0;
		}

		public static Card? FirstCardOnHand(this List<Card> cards)
		{
			return cards?.FirstOrDefault(x => x.FirstCard);
		}
	}
}
