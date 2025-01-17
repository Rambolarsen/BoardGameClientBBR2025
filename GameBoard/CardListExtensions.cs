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
				return 0;
			}

			return 0;
		}
	}
}
