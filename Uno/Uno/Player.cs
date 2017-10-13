using System;
namespace Uno
{
    class Player
    {
        private String name;
        private Hand<Card> pHand;
        private Deck<Card> deck;
        public Player(String playerName)
        {
            name = playerName;
        }

        public Hand<Card> getpHand()
        {
            return pHand;
        }

        public void setpHand(Hand<Card> newHand)
        {
            pHand = newHand;
        }

        public void DealToHand(Card c)
        {
            pHand.DealToHand(c);
        }

        public Card DoTurn()
        {
            Console.WriteLine("It is now " + name + "'s turn");
            Console.Write(pHand.ToString());
            Console.WriteLine("play a card!");
            int played = int.Parse(Console.ReadLine());

            return;
        }
    }
}
