using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    class Hand<T> : Pile<T> {
        
        public void DealToHand(T card) {
            Add(card);
        }

        public T PlayCard(T card) {
            return Take(card);
        }
    }
}
