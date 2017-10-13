using System;
namespace Uno {
    class Player {
        private string name;
        private Hand<Card> _hand;

        public Hand<Card> Hand => _hand;

        public Player(string playerName) {
            name = playerName;
            _hand = new Hand<Card>();
        }

        public void DealToHand(Card c) {
            _hand.DealToHand(c);
        }

        public Card DoTurn()
        {
            Console.WriteLine($"It is now {name}'s turn");
            Console.Write(_hand.ToString());
            Console.WriteLine("play a card!");

            int played = int.Parse(Console.ReadLine());
            return _hand.PlayCard(played);
        }
        public Boolean HasWon(){
            return _hand.GetSize() == 0;
        }
    }
}
