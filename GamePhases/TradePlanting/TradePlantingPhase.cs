﻿using BoardGameClientBBR2025.API;
using BoardGameClientBBR2025.GameBoard;

namespace BoardGameClientBBR2025.GamePhases.TradePlanting;

public class TradePlantingPhase : PlantingPhaseBase, IGamePhase
{
    public override GamePhaseEnum GamePhase => GamePhaseEnum.TradePlanting;

    protected override async Task PhaseImplementation(string gameName, string ourPlayerId, string ourPlayerName, DateTime phaseEnds, List<Card> ourHand, Player activePlayer, Player us, PlayingClient playingClient)
    {
		var cardsToPlant = new List<Card>();
		cardsToPlant.AddRange(activePlayer.DrawnCards);
		cardsToPlant.AddRange(activePlayer.TradedCards);

		foreach (var card in cardsToPlant)
		{
			var field = FindBestFieldToPlantOn(card, activePlayer.Fields);
			await field.TradePlantBean(card, gameName, ourPlayerId, playingClient);
		}
	}
}