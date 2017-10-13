using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    class Hand<T> {

        private List<T> _hand;

        public void DealToHand(T card) {
            _hand.Add(card);
        }

        public void DealToHand(T[] cards) {
            _hand.AddRange(cards);
        }

        public T PlayCard(T card) {
            T removedCard = _hand[_hand.IndexOf(card)];
            _hand.Remove(card);
            return removedCard;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach(T item in _hand) {
                sb.Append(item.ToString() + " ");
            }

            return sb.ToString();
        }
    }
}
