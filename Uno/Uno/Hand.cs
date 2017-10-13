using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    class Hand<Card> {

        private List<Card> _hand;

        public void DealToHand(Card card) {
            _hand.Add(card);
        }

        public void DealToHand(Card[] cards) {
            _hand.AddRange(cards);
        }

        public Card PlayCard(Card card) {
            Card removedCard = _hand[_hand.IndexOf(card)];
            _hand.Remove(card);
            return removedCard;
        }
    }
}
