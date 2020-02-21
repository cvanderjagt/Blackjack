using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    class BaseCard
    {
        public char Suit
        { get; set; }
        public char Value
        { get; set; }
        public String GetCard()
        {
            return String.Concat(Suit, Value);
        }
    }
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
    class Blackjack
    {
        readonly Hand playerHand = new Hand();
        readonly Hand computerHand = new Hand();
        readonly Deck deck = new Deck();
        void Deal()
        {
            
            for (int i = 0; i < 2; i++)
            {
                playerHand.Draw(deck);
                computerHand.Draw(deck);
            }
        }
        void PrintHands(bool showDealer)
        {
            List<BaseCard> computerCards = computerHand.cards;
            List<BaseCard> playerCards = playerHand.cards;
            Console.Write("Dealer's Hand:");
            if (showDealer)
            {
                for (int i = 0; i < computerCards.Count(); i++)
                {
                    Console.Write(" " + computerCards[i].GetCard());
                }
                Console.Write("\nTotal: " + computerHand.CardValue + "");
            }
            else
            {
                Console.Write(" **");
                for (int i = 1; i < computerCards.Count(); i++)
                {
                    Console.Write(" " + computerCards[i].GetCard());
                }
            }
            Console.Write("\n\nYour Hand:");
            for (int i = 0; i < playerCards.Count(); i++)
            {
                Console.Write(" " + playerCards[i].GetCard());
            }
            Console.WriteLine("\nTotal: " + playerHand.CardValue + "\n\n");
        }
        void ComputerTurn()
        {
            if (computerHand.CardValue >= playerHand.CardValue)
            {
                Console.WriteLine("You lose");
                return;
            }
            while (computerHand.CardValue < 17)
            {
                computerHand.Draw(deck);
            }
            PrintHands(true);
            if (computerHand.CardValue > 21 || computerHand.CardValue < playerHand.CardValue)
            {
                Console.WriteLine("You win");
            }
            else
            {
                Console.WriteLine("You lose");
            }
        }
        void PlayLoop()
        {
            while (true)
            {
                PrintHands(false);
                if (playerHand.CardValue == 21 && computerHand.CardValue == 21)
                {
                    Console.WriteLine("Tie");
                    return;
                }
                else if (computerHand.CardValue == 21 || playerHand.CardValue > 21)
                {
                    Console.WriteLine("You lose");
                    return;
                }
                else if (playerHand.CardValue == 21 || computerHand.CardValue > 21)
                {
                    Console.WriteLine("You win");
                    return;
                };
                string selection;
                Console.WriteLine("1.) Stand");
                Console.WriteLine("2.) Hit");
                do
                {
                    selection = Console.ReadLine();
                    Console.WriteLine();
                    switch (selection)
                    {
                        case "1":
                            ComputerTurn();
                            return;
                        case "2":
                            playerHand.Draw(deck);
                            break;
                        default:
                            Console.WriteLine("Invalid Selection");
                            break;
                    }
                } while (selection != "1" && selection != "2");
            }

        }
        static void Main()
        {
            Blackjack blkjk = new Blackjack();
            blkjk.Deal();
            blkjk.PlayLoop();
            Console.ReadLine();
        }
    }
}
