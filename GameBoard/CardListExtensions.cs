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

			var currentExchangeMap = cards.CurrentExchangeMap();

			return currentExchangeMap?.Value ?? 0;
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

			var aCard = cards.First();
			var maxExchangeMap = aCard.ExchangeMap.MaxExchangeMap();

			return cards.Count >= maxExchangeMap.CropSize;
		}

		public static decimal Potential(this List<Card> cards)
		{
			if (!cards.Any())
			{
				return 10;
			}

			if (cards.IsMaxCropSize())
			{
				return 0;
			}

			var numberOfCardsToNextExchangeMap = cards.NumberOfCardsToNextExchangeMap();
			var valueIncreaseOnNextExchangeMap = cards.ValueIncreaseOnNextExchangeMap();

			return (decimal)valueIncreaseOnNextExchangeMap/numberOfCardsToNextExchangeMap;
		}

		public static int NumberOfCardsToNextExchangeMap(this List<Card> cards)
		{
			const int infiniteNumberOfCards = 10;
			
			if (!cards.Any())
			{
				return infiniteNumberOfCards;
			}

			if (!cards.AllCardsAreOfSameType())
			{
				return infiniteNumberOfCards;
			}

			var currentExchangeMap = cards.CurrentExchangeMap();
			if (currentExchangeMap == null)
			{
				return cards.MinExchangeMap()?.CropSize ?? infiniteNumberOfCards;
			}

			var nextExchangeMap = cards.NextExchangeMap();

			if (nextExchangeMap == null)
			{
				return infiniteNumberOfCards;
			}

			return nextExchangeMap.CropSize - currentExchangeMap.CropSize;
		}

		public static int ValueIncreaseOnNextExchangeMap(this List<Card> cards)
		{
			const int aNiceAverageValue = 1;
			
			if (!cards.Any())
			{
				return aNiceAverageValue;
			}

			if (!cards.AllCardsAreOfSameType())
			{
				return 0;
			}

			var currentExchangeMap = cards.CurrentExchangeMap();
			if (currentExchangeMap == null)
			{
				return cards.MinExchangeMap()?.Value ?? aNiceAverageValue;
			}
			
			var nextExchangeMap = cards.NextExchangeMap();

			if (nextExchangeMap == null)
			{
				return 0;
			}

			return nextExchangeMap.Value - currentExchangeMap.Value;
		}

		public static Card FirstCardOnHand(this List<Card> cards)
		{
			return cards.First(x => x.FirstCard);
		}

		public static ExchangeMap? CurrentExchangeMap(this List<Card> cards)
		{
			if (!cards.Any())
			{
				return null;
			}

			if (!cards.AllCardsAreOfSameType())
			{
				return null;
			}

			var aCard = cards.First();

			return aCard.ExchangeMap.CurrentExchangeMap(cards.Count);
		}

		public static ExchangeMap? NextExchangeMap(this List<Card> cards)
		{
			if (!cards.Any())
			{
				return null;
			}
			
			if (cards.IsMaxCropSize())
			{
				return cards.MaxExchangeMap();
			}

			var aCard = cards.First();

			return aCard.ExchangeMap.NextExchangeMap(cards.Count);
		}

		public static ExchangeMap? MaxExchangeMap(this List<Card> cards)
		{
			if (!cards.Any())
			{
				return null;
			}

			if (!cards.AllCardsAreOfSameType())
			{
				return null;
			}

			return cards.First().ExchangeMap.MaxExchangeMap();
		}

		public static ExchangeMap? MinExchangeMap(this List<Card> cards)
		{
			if (!cards.Any())
			{
				return null;
			}

			if (!cards.AllCardsAreOfSameType())
			{
				return null;
			}

			return cards.First().ExchangeMap.MinExchangeMap();
		}
	}
}
