using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    class Deck<T> {
        private List<T> _played;
        private List<T> _unPlayed;

        public T Top => _unPlayed[0];

        public Deck() : this(new List<T>()) { }
        public Deck(List<T> cards) : base() {
            _played = cards;
        }

        public void Play(T play) {
            _played.Add(play);
        }

        public T Take() {
            return _unPlayed.Take(1).ToArray()[0];
        }

        public void Shuffle() {
            List<T> tmp = new List<T>(_unPlayed);
            Random r = new Random();
            for (int i = 0; i < _unPlayed.Count; i++) {
                int index = r.Next(tmp.Count);
                _unPlayed[i] = tmp[index];
                tmp.RemoveAt(index);
            }
        }
    }
}
