namespace Uno;
public class Player
{
    public string Name { get; set; } = "";

    public List<Card> Hand { get; set; } = new List<Card>();


    public bool HasPlayableCard(Card card)
    {
        return Hand.Any(c => Card.PlaysOn(c, card));
    }

    public Card GetFirstPlayableCard(Card card)
    {
        return Hand.FirstOrDefault(c => Card.PlaysOn(c, card));
    }


    public Color MostCommonColor()
    {
        int redCount = 0;
        int yellowCount = 0;
        int blueCount = 0;
        int greenCount = 0;
        foreach (Card card in Hand)
        {
            if (card.Color == Color.Red)
                redCount++;
            else if (card.Color == Color.Yellow)
                yellowCount++;
            else if (card.Color == Color.Blue)
                blueCount++;
            else if (card.Color == Color.Green)
                greenCount++;
        }
        if (redCount == 0 && yellowCount == 0 && blueCount == 0 && greenCount == 0)
            return Color.Wild;
        int[] counts = { redCount, yellowCount, blueCount, greenCount };
        Color[] colors = { Color.Red, Color.Yellow, Color.Blue, Color.Green };

        int maxCount = counts[0];
        Color mostCommon = colors[0];

        for (int i = 1; i < counts.Length; i++)
        {
            if (counts[i] > maxCount)
            {
                maxCount = counts[i];
                mostCommon = colors[i];
            }
        }
        return mostCommon;
    }
}