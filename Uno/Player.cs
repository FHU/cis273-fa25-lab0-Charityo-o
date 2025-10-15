namespace Uno;

public class Player
{
    public string Name { get; set; } = "";

    public List<Card> Hand { get; set; } = new List<Card>();


    public bool HasPlayableCard(Card card)
    {
        return true;
    }

    public Card GetFirstPlayableCard(Card card)
    {
        return null;
    }


    public Color MostCommonColor()
    {
        return Color.Red;
    }

}