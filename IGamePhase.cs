﻿namespace BoardGameClientBBR2025
{
	public interface IGamePhase
	{
		GamePhaseEnum GamePhase { get; set; }
		string PhaseName { get; set; }
	}
}
