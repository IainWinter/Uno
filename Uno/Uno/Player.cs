using System;
namespace Uno
{
    public class Player
    {
        private String name;
        private Hand<Card> pHand;
        private Deck<Card> deck;
        public Player(String playerName,Deck<Card> currentDeck){
            name = playerName;
            deck = currentDeck;
            pHand.DealToHand(deck.Take(7));


        }



        public Card DoTurn(){
            Console.Write(pHand.ToString());
        }
    }
}
