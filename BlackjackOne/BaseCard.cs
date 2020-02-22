using System;

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