using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    class Program {
        static void Main(string[] args) {
            Deck<Card> cards = new Deck<Card>();
            cards.Take(new Card(CardColor.Blue, CardType.DrawTwo));


            Console.Write(Console.ReadLine());
        }
    }
}
