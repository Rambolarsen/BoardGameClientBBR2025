namespace BoardGameClientBBR2025
{
    public static class Constants
    {
        public const string BaseUrl = "https://localhost:7046/api";

        //public const string BaseUrl = "http://f540-193-212-67-198.ngrok-free.app/api";

        public const string GameUrl = $"{BaseUrl}/game";

        public const string PlayingUrl = $"{BaseUrl}/playing";

        public const string ScoreUrl = $"{BaseUrl}/score";

        public static readonly Guid AgentId = new Guid("44c81fd9-8124-4acf-a1bd-fd6b54a8f5ca");

        public const string PlayerName = "Mjondalen";


    }
}
