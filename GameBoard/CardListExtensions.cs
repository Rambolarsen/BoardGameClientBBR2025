using System.Xml.Linq;

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

		public static decimal Potential(this List<Card> cards)
		{
			if (!cards.Any())
			{
				return 100;
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
			if (!cards.Any())
			{
				//Infinite
				return 100;
			}

			if (!cards.AllCardsAreOfSameType())
			{
				//infinite
				return 100;
			}

			var currentExchangeMap = cards.CurrentExchangeMap();
			if (currentExchangeMap == null)
			{
				return cards.MinExchangeMap()?.CropSize ?? 0;
			}

			var nextExchangeMap = cards.NextExchangeMap();

			if (nextExchangeMap == null)
			{
				//infinite
				return 100;
			}

			return nextExchangeMap.CropSize - currentExchangeMap.CropSize;
		}

		public static int ValueIncreaseOnNextExchangeMap(this List<Card> cards)
		{
			if (!cards.Any())
			{
				//A nice value?
				return 1;
			}

			if (!cards.AllCardsAreOfSameType())
			{
				return 0;
			}

			var currentExchangeMap = cards.CurrentExchangeMap();
			if (currentExchangeMap == null)
			{
				return cards.MinExchangeMap()?.Value ?? 0;
			}
			
			var nextExchangeMap = cards.NextExchangeMap();

			if (nextExchangeMap == null)
			{
				return 0;
			}

			return nextExchangeMap.Value - currentExchangeMap.Value;
		}

		public static Card? FirstCardOnHand(this List<Card> cards)
		{
			return cards.FirstOrDefault(x => x.FirstCard);
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

			var firstCard = cards.First();

			foreach (var oneExchangeValue in firstCard.ExchangeMap.OrderBy(x => x.CropSize))
			{
				if (cards.Count >= oneExchangeValue.CropSize)
				{
					return oneExchangeValue;
				}
			}

			return null;
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

			var currentExchangeMap = cards.CurrentExchangeMap();

			if (currentExchangeMap == null)
			{
				return cards.MinExchangeMap();
			}

			return cards.First().ExchangeMap.OrderBy(x => x.CropSize).FirstOrDefault(x => x.CropSize > currentExchangeMap.CropSize);
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

			return cards.First().ExchangeMap.OrderByDescending(x => x.CropSize).First();
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

			return cards.First().ExchangeMap.OrderBy(x => x.CropSize).First();
		}
	}
}
