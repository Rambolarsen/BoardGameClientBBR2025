public class BohnanzaDeck
{
    // Enum to define the different types of beans
    public enum BeanType
    {
        GardenBean,
        BlackEyedBean,
        StinkBean,
        BlueBean,
        GreenBean,
        RedBean,
        ChiliBean,
        SoyBean,
    }

    // Dictionary to hold the quantity of each type of bean
    private Dictionary<BeanType, int> deck;

    // Constructor to initialize the deck with the correct quantities
    public BohnanzaDeck()
    {
        deck = new Dictionary<BeanType, int>
        {
            { BeanType.GardenBean, 6 },
            { BeanType.RedBean, 8 },
            { BeanType.BlackEyedBean, 10 },
            { BeanType.SoyBean, 12 },
            { BeanType.GreenBean, 14 },
            { BeanType.StinkBean, 16 },
            { BeanType.ChiliBean, 18 },
            { BeanType.BlueBean, 20 },
        };
    }

    // Method to get the total number of cards in the deck
    public int GetTotalCards()
    {
        int total = 0;
        foreach (var entry in deck)
        {
            total += entry.Value;
        }
        return total;
    }

    // Method to get the number of a specific type of bean in the deck
    public int GetBeanCount(BeanType beanType)
    {
        if (deck.ContainsKey(beanType))
        {
            return deck[beanType];
        }
        return 0;
    }

    // Method to display the current deck overview
    public void DisplayDeckOverview()
    {
        Console.WriteLine("Bohnanza Deck Overview:");
        foreach (var entry in deck)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} cards");
        }
        Console.WriteLine($"Total cards in deck: {GetTotalCards()}");
    }
}