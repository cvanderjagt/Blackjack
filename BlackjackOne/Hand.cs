using System;
using System.Collections.Generic;
using System.Linq;

class Hand
{
    public List<BaseCard> cards = new List<BaseCard>();
    private int softAce = 0;
    readonly Random rand = new Random();
    public int CardValue { get; private set; } = 0;
    public void Draw(Deck currentDeck)
    {
        var availableCards = Enumerable.Range(0, 52).Where(i => !currentDeck.discards.Contains(i));
        int index = rand.Next(0, 51 - currentDeck.discards.Count);
        BaseCard selectedCard = currentDeck.cards[availableCards.ElementAt(index)];
        cards.Add(selectedCard);
        currentDeck.discards.Add(availableCards.ElementAt(index));
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