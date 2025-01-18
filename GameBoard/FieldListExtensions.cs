namespace BoardGameClientBBR2025.GameBoard
{
	public static class FieldListExtensions
	{
		public static bool HarvestFieldIsAllowed(this List<Field> fields, Field fieldToHarvest)
		{
			if (fieldToHarvest.Card.Count > 1)
			{
				return true;
			}

			if (fieldToHarvest.Card.Count < 1)
			{
				return false;
			}

			if (fields.Any(x => x.Card.Count > 1))
			{
				return false;
			}

			return true;
		}

		public static List<Field> AllowedToHarvest(this List<Field> fields)
		{
			return fields.Where(fields.HarvestFieldIsAllowed).ToList();
		}
	}
}
