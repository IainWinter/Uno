using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    public class Pile<T> {
        private List<T> pile;

        public Pile() : this(0) { }
        public Pile(int capacity) : this(new List<T>(capacity)) { }
        public Pile(List<T> collection) {
            pile = collection;
        }
    }
}
