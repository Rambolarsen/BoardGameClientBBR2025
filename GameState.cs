using System;
using System.Collections.Generic;

namespace BoardGameClientBBR2025
{
    public class GameState
    {
        public string Name { get; set; }
        public string CurrentPlayer { get; set; }
        public string CurrentPhase { get; set; }
        public string CurrentState { get; set; }
        public int Round { get; set; }
        public string PhaseTimeLeft { get; set; }
        public DateTime PhaseEndTimestamp { get; set; }
        public DateTime LastStateChange { get; set; }
        public int Deck { get; set; }
        public List<Trade> AvailableTrades { get; set; }
        public List<object> DiscardPile { get; set; }
        public List<Player> Players { get; set; }
        public List<Card> YourHand { get; set; }
    }

    public class Trade
    {
        public Guid InitiatorId { get; set; }
        public Guid NegotiationId { get; set; }
        public List<string> OfferedCards { get; set; }
        public List<string> CardTypesWanted { get; set; }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Coins { get; set; }
        public List<Field> Fields { get; set; }
        public int Hand { get; set; }
        public List<object> DrawnCards { get; set; }
        public List<object> TradedCards { get; set; }
        public bool IsActive { get; set; }
    }

    public class Field
    {
        public Guid Key { get; set; }
        public List<Card> Card { get; set; }
    }

    public class Card
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public List<ExchangeMap> ExchangeMap { get; set; }
        public bool FirstCard { get; set; } // Added to match the "yourHand" structure
    }

    public class ExchangeMap
    {
        public int CropSize { get; set; }
        public int Value { get; set; }
    }
}