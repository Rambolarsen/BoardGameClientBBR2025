namespace BoardGameClientBBR2025.GameBoard
{
	public static class PlayerExtensions
	{
		public static Player? GetActivePlayer(this IEnumerable<Player> playerPool)
		{
			return playerPool.FirstOrDefault(x => x.IsActive);
		}
	}
}
