using System;

public class BaseCard
{
    public char Suit { get; private set; }
    public char Value { get; private set; }
    public BaseCard(char suit, char value)
    {
        Suit = suit;
        Value = value;
    }
    public String GetCard()
    {
        return String.Concat(Suit, Value);
    }
}