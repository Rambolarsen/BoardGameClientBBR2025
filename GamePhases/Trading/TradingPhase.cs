using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Trading;

public class TradingPhase : GamePhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.Trading;
    private List<Card> _wantCards = [];
    private List<Card> _getRidOfCards = [];

	protected override async Task PhaseImplementation(string gameName, string ourPlayerId, string ourPlayerName, List<Card> ourHand, Player activePlayer, Player us, PlayingClient playingClient)
    {
		CalculatePossibleTrades(ourPlayerId, ourPlayerName, ourHand, us);
		await OfferTrades(gameName, ourPlayerId, ourPlayerName, playingClient);
	    
	    await playingClient.EndTrading(gameName, ourPlayerId);
	}

	public void CalculatePossibleTrades(string ourPlayerId, string ourPlayerName, List<Card> ourHand, Player us)
	{
		var ourFields = us.Fields;

		var drawnCards = new List<Card>();
		if (us.IsActive)
		{
			drawnCards = us.DrawnCards;
		}

		_wantCards = FindWantCards(ourHand, drawnCards, ourFields);
		_getRidOfCards = FindGetRidOfCards(ourHand, drawnCards, ourFields);
	}

	public async Task ConsiderTrades(string gameName, string ourPlayerId, string ourPlayerName, GameState gameState, PlayingClient playingClient)
	{
		//foreach (var oneTrade in gameState.AvailableTrades)
		//{
		//	foreach (var oneTypeOffered in oneTrade.CardTypesWanted)
		//	{
		//		if (_wantCards.Any(x => x.Type == oneTypeOffered))
		//		{
		//			foreach (var oneTypeWanted in oneTrade.CardTypesWanted)
		//			{
		//				if (_getRidOfCards.Any(x => x.Type == oneTypeWanted))
		//				{
		//					playingClient.AcceptTrade(gameName, )
		//				}
		//			}
		//		}
		//	}
		//}
	}

	private async Task OfferTrades(string gameName, string ourPlayerId, string ourPlayerName, PlayingClient playingClient)
	{
		await playingClient.RequestTrade(gameName, ourPlayerId);
	}

	private List<Card> GetAvailableCards(List<Card> ourHand, List<Card> drawnCards)
	{
		var availableCards = new List<Card>();

		availableCards.AddRange(ourHand);
		availableCards.AddRange(drawnCards);

		return availableCards;
	}

	private List<Card> GetCardTypesFromFields(List<Field> ourFields)
	{
		var fieldCardTypes = new List<Card>();

		foreach (var field in ourFields)
		{
			if (!field.IsEmpty())
			{
				fieldCardTypes.Add(field.Card.First());
			}
		}

		return fieldCardTypes;
	}

	private List<Card> FindWantCards(List<Card> ourHand, List<Card> drawnCards, List<Field> ourFields)
	{
		return GetCardTypesFromFields(ourFields);
	}

	private List<Card> FindGetRidOfCards(List<Card> ourHand, List<Card> drawnCards, List<Field> ourFields)
	{
		var cardsToGetRidOf = new List<Card>();
		var cardsAvailable = GetAvailableCards(ourHand, drawnCards);
		var cardsOnField = GetCardTypesFromFields(ourFields);

		foreach (var oneAvailableCard in cardsAvailable)
		{
			if (cardsOnField.All(x => x.Type != oneAvailableCard.Type))
			{
				cardsToGetRidOf.Add(oneAvailableCard);
			}
		}

		return cardsToGetRidOf;
	}
}