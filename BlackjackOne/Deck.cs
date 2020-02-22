using System.Collections.Generic;

class Deck
{
    public BaseCard[] cards = new BaseCard[52];
    public HashSet<int> discards = new HashSet<int>();

    public Deck()
    {
        char[] suits = { 'C', 'S', 'H', 'D' };
        char[] values = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'J', 'Q', 'K', 'A' };
        for (int i = 0; i < 52; i++)
        {
            cards[i] = new BaseCard();
        }
        for (int j = 0; j < suits.Length; j++)
        {
            for (int k = 0; k < values.Length; k++)
            {
                int currentCard = j * values.Length + k;
                cards[currentCard].Suit = suits[j];
                cards[currentCard].Value = values[k];
            }
        }
    }
}