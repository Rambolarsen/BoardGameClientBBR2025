namespace BoardGameClientBBR2025.GameBoard
{
	public class Card : ICard
	{
		public Guid Id { get; set; }
		public string Type { get; set; } = string.Empty;
		public List<ExchangeMap> ExchangeMap { get; set; } = [];
		public bool FirstCard { get; set; }
		public BeanType BeanType => Type.ToBeanType();

		protected Card(ICard copy)
		{
			Id = copy.Id;
			Type = copy.Type;
			ExchangeMap = copy.ExchangeMap;
			FirstCard = copy.FirstCard;
		}
		
		public int CoinValue(int numberOfCards)
		{
			foreach (var oneExchangeValue in ExchangeMap.OrderBy(x => x.CropSize))
			{
				if (numberOfCards >= oneExchangeValue.CropSize)
				{
					return oneExchangeValue.Value;
				}
			}

			return 0;
		}
	}
}
