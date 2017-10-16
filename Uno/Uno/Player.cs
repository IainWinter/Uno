using System;
using System.Collections.Generic;

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
            } while (card.color != topCard.color && card.type != topCard.type && card.type != CardType.Wild);

            _hand.PlayCard(cardIndex);
            return card;
        }

        public bool HasFinished() {
            return _hand.GetSize() == 0;
        }


        void sortCards() {
            List<int>[] cards = new List<int>[5];
            foreach(Card c in _hand) {

            }
        }
    }
}
