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

        public Card DoTurn(Card c) {
            Console.WriteLine($"It is now {name}'s turn!");
            Console.WriteLine();
            Console.WriteLine($"-------- {name}'s Turn --------");
            Console.Write(_hand.ToString());
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("The top card is " + c.ToString());

            int cardIndex = 0;
            Card card;
            do {
                Console.WriteLine();
                Console.WriteLine("Play card: ");
                cardIndex = Console.Read() - 49;
                card = _hand[cardIndex];
            } while (card.type != c.type || card.color != c.color || card.type != CardType.Wild);

            return card;
        }

        public Boolean HasWon() {
            return _hand.GetSize() == 0;
        }
    }
}
