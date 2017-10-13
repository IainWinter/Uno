using System;
namespace Uno {
    class Player {
        private String name;
        private Hand<Card> _hand;

        public Hand<Card> Hand => _hand;

        public Player(String playerName) {
            name = playerName;
        }

        public Hand<Card> getpHand() {
            return _hand;
        }

        public void setpHand(Hand<Card> newHand) {
            _hand = newHand;
        }

        public void DealToHand(Card c) {
            _hand.DealToHand(c);
        }

        public Card DoTurn() {
            Console.WriteLine("It is now " + name + "'s turn");
            Console.Write(_hand.ToString());

            return;
        }
    }
}
