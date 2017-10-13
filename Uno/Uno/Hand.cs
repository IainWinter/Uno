using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    class Hand<TIdiot> {

        private List<TIdiot> _hand;

        public void DealToHand(TIdiot card) {
            _hand.Add(card);
        }

        public void DealToHand(TIdiot[] cards) {
            _hand.AddRange(cards);
        }

        public TIdiot PlayCard(TIdiot card) {
            TIdiot removedCard = _hand[_hand.IndexOf(card)];
            _hand.Remove(card);
            return removedCard;
        }
    }
}
