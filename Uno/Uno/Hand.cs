using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    class Hand<T> {
        private List<T> _hand;

        public Hand() {
            _hand = new List<T>();
        }

        public T this[int index] {
            get { return _hand[index]; }
            set { _hand[index] = value; }
        }

        public void DealToHand(T card) {
            _hand.Add(card);
        }

        public void DealToHand(T[] cards) {
            _hand.AddRange(cards);
        }

        public int GetSize() {
            return _hand.Count;
        }

        public T PlayCard(int index) {
            T card = _hand[index];
            _hand.RemoveAt(index);
            return card;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _hand.Count; i++) {
                sb.Append($"{i+1}. {_hand[i].ToString()}\n");
            }

            return sb.ToString();
        }
    }
}
