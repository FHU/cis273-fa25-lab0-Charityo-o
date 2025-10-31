namespace Uno;

public enum CardType
{
    Number, Wild, Draw2, WildDraw4, Skip, Reverse
}

public enum Color
{
    Red, Yellow, Blue, Green, Wild
}

public class Card
{
    private const string V = "Wild Draw 4";

    public CardType Type { get; set; }
    public Color Color { get; set; }
    public int? Number { get; set; }

    public static bool PlaysOn(Card card1, Card card2)
    {
        if (card1.Type == CardType.Wild || card1.Type == CardType.WildDraw4)
            return true;
        if (card1.Color == card2.Color)
            return true;
        if (card1.Type == CardType.Number && card2.Type == CardType.Number && card1.Number == card2.Number)
            return true;
        return false;
    }


    public override string ToString()
    {    
        return Type switch
        {
            CardType.Number => $"{Color} {Number}",
            CardType.Wild => "Wild",
            CardType.WildDraw4 => V,
            _ => $"{Color} {Number}"
        };
    }

}