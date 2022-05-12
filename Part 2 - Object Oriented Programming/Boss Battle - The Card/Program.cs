Console.Title = "The Card";

CardColor[] color = new CardColor[4] { CardColor.Red, CardColor.Blue, CardColor.Green, CardColor.Yellow };
CardRank[] rank = new CardRank[14] { CardRank.One, CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six, CardRank.Seven, CardRank.Eight, CardRank.Nine, CardRank.Ten, CardRank.DollarSign, CardRank.Percent, CardRank.Caret, CardRank.Ampersand };

foreach (CardColor cardColor in color)
{
    foreach (CardRank cardRank in rank)
    {
        Card newCard = new Card(cardColor, cardRank);
        Console.WriteLine($"Is Number:{newCard.IsNumber()}\nThe {newCard.CardColor} {newCard.CardRank}\n" );
    }
}
class Card
{
    public CardColor CardColor { get; }
    public CardRank CardRank { get; }

    public Card(CardColor cardColor, CardRank cardRank)
    {
        CardColor = cardColor;
        CardRank = cardRank;
    }

    public bool IsNumber() //if its a symbol, it will return false
    {
        bool isNumber = CardRank switch
        {
            CardRank.DollarSign => false,
            CardRank.Percent => false,
            CardRank.Caret => false,
            CardRank.Ampersand => false,
            _ => true
        };
        return isNumber;
    }
}

enum CardColor {Red, Blue, Green, Yellow}
enum CardRank {One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand}