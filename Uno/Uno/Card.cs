using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    struct Card {
        Color color;
        CardType type;
        
        public Card(Color c, CardType t) {
            color = c;
            type = t;
        }   

        public override string ToString() {
            string scolor = Enum.GetName(typeof(Color), color);
            string stype = Enum.GetName(typeof(CardType), type);
            if (scolor == "Wild")
                scolor = null;
            return scolor + " " + stype;
        }
    }
}
