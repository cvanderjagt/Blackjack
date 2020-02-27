using System;

 public class Program
{
    private static void Main()
    {
        Blackjack blkjk = new Blackjack();
        blkjk.Deal();
        blkjk.PlayLoop();
        Console.ReadLine();
    }
}
