using System.Text.Json.Serialization;

namespace BoardGameClientBBR2025
{
    public class GameState
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("currentPlayer")]
        public string CurrentPlayer { get; set; }

        [JsonPropertyName("currentPhase")]
        public string CurrentPhase { get; set; }

        [JsonPropertyName("currentState")]
        public string CurrentState { get; set; }

        [JsonPropertyName("round")]
        public int Round { get; set; }

        [JsonPropertyName("phaseTimeLeft")]
        public string PhaseTimeLeft { get; set; }

        [JsonPropertyName("phaseEndTimestamp")]
        public DateTime PhaseEndTimestamp { get; set; }

        [JsonPropertyName("lastStateChange")]
        public DateTime LastStateChange { get; set; }

        [JsonPropertyName("deck")]
        public int Deck { get; set; }

        [JsonPropertyName("availableTrades")]
        public List<Trade> AvailableTrades { get; set; }

        [JsonPropertyName("discardPile")]
        public List<object> DiscardPile { get; set; }

        [JsonPropertyName("players")]
        public List<Player> Players { get; set; }

        [JsonPropertyName("yourHand")]
        public List<Card> YourHand { get; set; }
    }

    public class Trade
    {
        [JsonPropertyName("initiatorId")]
        public Guid InitiatorId { get; set; }

        [JsonPropertyName("negotiationId")]
        public Guid NegotiationId { get; set; }

        [JsonPropertyName("offeredCards")]
        public List<string> OfferedCards { get; set; }

        [JsonPropertyName("cardTypesWanted")]
        public List<string> CardTypesWanted { get; set; }
    }

    public class Player
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("coins")]
        public int Coins { get; set; }

        [JsonPropertyName("fields")]
        public List<Field> Fields { get; set; }

        [JsonPropertyName("hand")]
        public int Hand { get; set; }

        [JsonPropertyName("drawnCards")]
        public List<object> DrawnCards { get; set; }

        [JsonPropertyName("tradedCards")]
        public List<object> TradedCards { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }

    public class Field
    {
        [JsonPropertyName("key")]
        public Guid Key { get; set; }

        [JsonPropertyName("card")]
        public List<Card> Card { get; set; }
    }

    public class Card
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("exchangeMap")]
        public List<ExchangeMap> ExchangeMap { get; set; }

        [JsonPropertyName("firstCard")]
        public bool FirstCard { get; set; }
    }

    public class ExchangeMap
    {
        [JsonPropertyName("cropSize")]
        public int CropSize { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}
