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
                Console.Write("Play card: ");
                cardIndex = int.Parse(Console.ReadLine()) - 1;
                card = _hand[cardIndex];
            } while (card.color != topCard.color && card.type != topCard.type && card.type != CardType.Wild && card.type != CardType.DrawFour);

            _hand.PlayCard(cardIndex);
            return card;
        }

        public bool HasWon() {
            return _hand.GetSize() == 0;
        }

        public bool CanPlay(Card topCard) {
            foreach(Card c in _hand) {
                if(c.color == topCard.color || c.type == topCard.type || c.type == CardType.Wild) {
                    return true;
                }
            }

            return false;
        }
    }
}
