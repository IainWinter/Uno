using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    class Program {
        static void Main(string[] args) {
            Player p = new Player("Iain!!");
            p.DealToHand(new Card(CardColor.Red, CardType.Five));
            p.DoTurn();

            Console.Write(Console.ReadLine());
        }
    }
}
