using System;
using System.Collections.Generic;
using System.Linq;

public class Hand
{
    private int softAce = 0;
    private readonly Random rand = new Random();
    public int CardValue { get; private set; } = 0;
    public List<BaseCard> cards { get; private set; } = new List<BaseCard>();
    public void Draw(Deck currentDeck)
    {
        int index = rand.Next(currentDeck.cards.Count);
        BaseCard selectedCard = currentDeck.cards.ElementAt(index);
        cards.Add(selectedCard);
        currentDeck.cards.Remove(currentDeck.cards.ElementAt(index));
        if ("JQK".Contains(selectedCard.Value))
        {
            CardValue += 10;
        }
        else if (selectedCard.Value == 'A')
        {
            softAce++;
            CardValue += 11;
        }
        else
        {
            CardValue += int.Parse(selectedCard.Value.ToString());
        }
        if (CardValue > 21 && softAce > 0)
        {
            CardValue -= 10;
            softAce--;
        }
    }
}