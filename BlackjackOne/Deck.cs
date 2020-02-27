using System.Collections.Generic;

public class Deck
{
    private readonly static char[] suits = { 'C', 'S', 'H', 'D' };
    private readonly static char[] values = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'J', 'Q', 'K', 'A' };

    public HashSet<BaseCard> cards { get; private set; } = new HashSet<BaseCard>();

    public Deck()
    {
        for (int j = 0; j < suits.Length; j++)
        {
            for (int k = 0; k < values.Length; k++)
            {
                cards.Add(new BaseCard(suits[j], values[k]));
            }
        }
    }
}