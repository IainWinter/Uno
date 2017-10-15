using System;
using System.Collections.Generic;
using System.Linq;

namespace Uno {
    class Deck<T> {
        private List<T> _played;
        private List<T> _unPlayed;

        public T Top => _played[_played.Count - 1];

        public Deck() : this(new List<T>()) { }
        public Deck(List<T> cards) : base() {
            _played = cards;
            _unPlayed = new List<T>();
        }

        public void Play(T play) {
            _played.Add(play);
        }

        public T Draw() {
            return _unPlayed.Take(1).ToArray()[0];
        }

        public void Add(T item) {
            _unPlayed.Add(item);
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
