using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uno {
    /// <summary>
    /// A completly usefull wrapper for a list and a linq methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pile<T> {
        private List<T> _pile;

        public Pile() : this(0) { }
        public Pile(int capacity) : this(new List<T>(capacity)) { }
        public Pile(List<T> collection) {
            _pile = collection;
        }

        public void Add(T item) {
            _pile.Add(item);
        }

        public void Add(T[] items) {
            _pile.AddRange(items);
        }

        public T Take() {
            return Take(1)[0];
        }

        public T[] Take(int n) {
            return _pile.Take(n).ToArray();
        }

        public T Top() {
            return _pile[0];
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach(T item in _pile) {
                sb.Append(item.ToString());
                sb.Append(' ');
            }

            return sb.ToString();
        }
    }
}
