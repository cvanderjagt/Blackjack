using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Blackjack
{
    private readonly Hand playerHand = new Hand();
    private readonly Hand computerHand = new Hand();
    private readonly Deck deck = new Deck();
    private const int drawLimit = 17;
    public void Deal()
    {
        for (int i = 0; i < 2; i++)
        {
            playerHand.Draw(deck);
            computerHand.Draw(deck);
        }
    }
    private void PrintHands(bool showDealer)
    {
        List<BaseCard> computerCards = computerHand.cards;
        List<BaseCard> playerCards = playerHand.cards;
        StringBuilder hands = new StringBuilder("Dealer's Hand:", 200);
        int i = 0;
        if (!showDealer)
        {
            i = 1;
            hands.Append(" **");
        }
        for (; i < computerCards.Count(); i++)
        {
            hands.AppendFormat(" {0}", computerCards[i].GetCard());
        }
        if (showDealer)
        {
            hands.AppendFormat("\nTotal: {0}", computerHand.CardValue);
        }
        hands.Append("\n\nYour Hand:");
        for (int j = 0; j < playerCards.Count(); j++)
        {
            hands.AppendFormat(" {0}", playerCards[j].GetCard());
        }
        hands.AppendFormat("\nTotal: {0}\n\n", playerHand.CardValue);
        Console.WriteLine(hands.ToString());
    }
    private void ComputerTurn()
    {
        while (computerHand.CardValue < drawLimit && computerHand.CardValue < playerHand.CardValue)
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
    private bool PlayerTurn()
    {
        string selection;
        bool continueLoop = true;
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
                    continueLoop = false;
                    break;
                case "2":
                    playerHand.Draw(deck);
                    break;
                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }
        } while (selection != "1" && selection != "2");
        return continueLoop;
    }
    public void PlayLoop()
    {
        bool continueLoop = true;
        while (continueLoop)
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
            continueLoop = PlayerTurn();
        }

    }
}