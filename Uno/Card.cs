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
    public CardType Type { get; set; }
    public Color Color { get; set; }
    public int? Number { get; set; }

    public override string ToString()
    {
        return Type switch
        {
            CardType.Number => $"{Color} {Number}",
            CardType.Wild => "Wild",
            CardType.WildDraw4 => "WildDraw4",
            CardType.Skip or CardType.Reverse or CardType.Draw2 => $"{Color} {Type}",
            _ => $"{Color} {Number}"
        };
    }
    public static bool PlaysOn(Card card1, Card card2)
    {
        if (card1.Type == CardType.Wild || card1.Type == CardType.WildDraw4)
            return true;
        if (card2.Type == CardType.Wild || card2.Type == CardType.WildDraw4)
            return true;
        if (card1.Color == card2.Color)
            return true;
        if (card1.Type == CardType.Number && card2.Type == CardType.Number && card1.Number == card2.Number)
            return true;
        if (card1.Type == card2.Type && card1.Type != CardType.Number)
            return true;
        return false;
    }

}