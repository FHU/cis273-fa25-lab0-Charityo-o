using System.Collections.Generic;
using System.Linq;

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
        var playableCard = Hand.FirstOrDefault(c => Card.PlaysOn(c, card));
        return playableCard;
    }

    public Color MostCommonColor()
    {
        var colorCount = new Dictionary<Color, int>
        {
            { Color.Red, 0 },
            { Color.Yellow, 0 },
            { Color.Blue, 0 },
            { Color.Green, 0 }
        };

        foreach (var card in Hand)
        {
            if (colorCount.ContainsKey(card.Color))
                colorCount[card.Color]++;
        }

        Color[] order = { Color.Red, Color.Yellow, Color.Blue, Color.Green };
        int max = -1;
        Color mostCommon = Color.Wild;

        foreach (var c in order)
        {
            if (colorCount[c] > max)
            {
                max = colorCount[c];
                mostCommon = c;
            }
        }

        return mostCommon;
    }
}