using System;
using System.Collections.Generic;

public class BohnanzaDeck
{
    // Enum to define the different types of beans
    public enum BeanType
    {
        BlueBean,
        GreenBean,
        RedBean,
        YellowBean,
        ChiliBean,
        SoyBean,
        CoffeeBean
    }

    // Dictionary to hold the quantity of each type of bean
    private Dictionary<BeanType, int> deck;

    // Constructor to initialize the deck with the correct quantities
    public BohnanzaDeck()
    {
        deck = new Dictionary<BeanType, int>
        {
            { BeanType.BlueBean, 11 },
            { BeanType.GreenBean, 11 },
            { BeanType.RedBean, 11 },
            { BeanType.YellowBean, 11 },
            { BeanType.ChiliBean, 6 },
            { BeanType.SoyBean, 6 },
            { BeanType.CoffeeBean, 6 }
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

class Program
{
    static void Main(string[] args)
    {
        // Create a new deck of Bohnanza
        var bohnanzaDeck = new BohnanzaDeck();

        // Display the deck overview
        bohnanzaDeck.DisplayDeckOverview();
        
        // Example of querying a specific bean count
        Console.WriteLine($"Number of BlueBeans: {bohnanzaDeck.GetBeanCount(BohnanzaDeck.BeanType.BlueBean)}");
    }
}
