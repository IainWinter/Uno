using System;
namespace Uno {
    class Player {
        public string name;
        private Hand<Card> _hand;

        public Hand<Card> Hand => _hand;

        public Player(string playerName) {
            name = playerName;
            _hand = new Hand<Card>();
        }

        public void DealToHand(Card topCard) {
            _hand.DealToHand(topCard);
        }

        public Card ChooseCard(Card topCard) {
            Console.WriteLine($"It is now {name}'s turn!");
            Console.WriteLine();
            Console.WriteLine($"-------- {name}'s Turn --------");
            Console.Write(_hand.ToString());
            Console.WriteLine();
            Console.Write("The top card is " + topCard.ToString());

            int cardIndex = 0;
            Card card;
            do {
                Console.WriteLine();
                string input = "";
                while (int.TryParse(input, out cardIndex) && cardIndex >= 0 && cardIndex < _hand.GetSize()) {
                    Console.Write("Play card: ");
                    input = Console.ReadLine();
                }
                card = _hand[cardIndex - 1];
            } while (card.color != topCard.color && card.type != topCard.type && card.type != CardType.Wild && card.color != CardColor.Wild);

            _hand.PlayCard(cardIndex);
            return card;
        }

        public bool HasFinished() {
            return _hand.GetSize() == 0;
        }

        public bool CanPlay(Card topCard) {
            foreach(Card c in _hand) {
                if(c.color == topCard.color || c.type == topCard.type || c.type == CardType.Wild || c.color == CardColor.Wild) {
                    return true;
                }
            }

            return false;
        }
    }
}
