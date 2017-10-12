using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    public class Deck<T> : Pile<T> {
        private List<T> _played;

        public Deck() : base() {
            _played = new List<T>();
        }

        public void Play(T play) {
            _played.Add(play);
        }

        public T Deal() {
            return Take();
        }
    }
}
