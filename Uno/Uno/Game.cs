using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    class Game
    {

        private Deck<Card> cards;
        private Player[] players;
        private int currentPlayer;
        private bool gameActive;

        public Game()
        {

        }

        public void Start()
        {
            Init();
            //run the game
        }

        void Init()
        {
            int playerCount = int.Parse(GetInput("How many players?: "));
            players = new Player[playerCount];
            for (int i = 1; i <= playerCount; i++)
            {
                players[i] = new Player(GetInput("Player " + i + " name: "));
            }
            cards = new Deck<Card>();
            gameActive = true;
            currentPlayer = 0;
        }

        void TurnCycle()
        {

        }

        string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

    }
}
