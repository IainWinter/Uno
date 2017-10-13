using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno {
    struct Card {
        CardColor color;
        CardType type;
        
        public Card(CardColor c, CardType t) {
            color = c;
            type = t;
        }   

        public override string ToString() {
            string scolor = Enum.GetName(typeof(CardColor), color);
            string stype = Enum.GetName(typeof(CardType), type);
            if (scolor == "Wild")
                return stype;
            else 
                return scolor + " " + stype;
        }
    }
}
