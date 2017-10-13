using System;
namespace Uno {
    class Player {
        private String name;
        private Hand<Card> _hand;

        public Hand<Card> Hand => _hand;

        public Player(String playerName) {
            name = playerName;
        }

        public void DealToHand(Card c) {
            _hand.DealToHand(c);
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
