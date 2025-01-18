using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.Trading;

public class TradingPhase : GamePhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.Trading;
    private List<Card> _wantCards = [];
    private List<Card> _getRidOfCards = [];

	protected override async Task PhaseImplementation(string gameName, string ourPlayerId, string playerName, List<Card> ourHand, Player activePlayer, PlayingClient playingClient)
    {
		await playingClient.EndTrading(gameName, ourPlayerId);
	}

	public async Task ConsiderTrades(string gameName, string ourPlayerId, string ourPlayerName,
		List<Trade> availableTrades, GameState gameState)
	{
	}

	public async Task<List<Trade>> OfferTrades(string gameName, string ourPlayerId, string ourPlayerName,
		List<Trade> availableTrades, GameState gameState)
	{
		return new List<Trade>();
	}

	private List<Card> FindWantCards(List<Card> ourHand, List<Card> drawnCards, List<Field> ourFields)
	{
		return new List<Card>();
	}
}