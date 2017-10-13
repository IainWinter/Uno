using System;
namespace Uno {
    class Player {
        private string name;
        private Hand<Card> _hand;

        public Hand<Card> Hand => _hand;

        public Player(string playerName) {
            name = playerName;
            _hand = new Hand<Card>();
        }

        public void DealToHand(Card c) {
            _hand.DealToHand(c);
        }

        public Card DoTurn(Card c)
        {
            Console.WriteLine($"It is now {name}'s turn");
            Console.Write(_hand.ToString());
            Console.Write("The top card is " + c.ToString());
            Console.WriteLine("play a card!");

            int played = int.Parse(Console.ReadLine());
            Card playedCard = _hand.PlayCard(played);
            while (true){
                if (playedCard.GetType() == c.GetType() || playedCard.GetColor() == c.GetColor() || playedCard.GetType() == CardType.Wild){
                    return playedCard;
                }
                else{
                    Console.WriteLine("Invalid play, try again");
                }
            }
        }

        public Boolean HasWon(){
            return _hand.GetSize() == 0;
        }
    }
}
