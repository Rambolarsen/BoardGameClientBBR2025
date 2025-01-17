namespace BoardGameClientBBR2025.GameBoard
{
	public class CardBase : ICard
	{
		public Guid Id { get; set; }
		public string Type { get; set; } = string.Empty;
		public List<ExchangeMap> ExchangeMap { get; set; } = [];
		public bool FirstCard { get; set; }
	}
}
