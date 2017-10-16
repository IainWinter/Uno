﻿using System;
using System.Collections.Generic;

namespace Uno {
    class Game {
        private Deck<Card> cards;
        public List<Player> players;
        private bool gameActive;
        private Player[] winners;
        private int currentPlayer;
        private int nextPlace;
        private int dir;
        private CardColor nClr;

        public Game() {
            cards = new Deck<Card>();
            players = new List<Player>();
            gameActive = true;
            nextPlace = 1;
            dir = 1;
        }

        public void Start() {
            Init();

            while (players.Count > 1) {
                Turn();
            }

            winners[winners.Length - 1] = players[0];
            Console.WriteLine();
            for (int i = 0; i < winners.Length; i++) {
                Console.WriteLine(i + ": " + winners[i].name);
            }

        }

        void Init() {
            int playerCount = int.Parse(GetInput("How many players?: "));
            players = new List<Player>();
            for (int i = 1; i <= playerCount; i++) {
                players.Add(new Player(GetInput("Player " + i + " name: ")));
            }
            winners = new Player[playerCount];
            GenerateDeck();
            cards.Shuffle();
            cards.Play(cards.Draw());

            //Deal to players
            foreach(Player p in players) {
                for (int i = 0; i < 7; i++) {
                    p.DealToHand(cards.Draw());
                }
            }
        }

        void Turn() {
            Player p = players[currentPlayer];
            cards.Play(p.ChooseCard(cards.Top.type == CardType.Wild ? new Card(nClr, CardType.Wild) : cards.Top));
            if (p.HasWon()) {
                players.Remove(p);
                winners[nextPlace - 1] = p;
                nextPlace++;
            }
            Iterate();
        }

        int Iterate(int i) {
            i = i += dir;
            if (i < 0 || i >= players.Count) {
                i = dir == 1 ? 0 : players.Count - 1;
            }
            return i;
        }

        void Iterate() {
            currentPlayer = currentPlayer += dir;
            if (currentPlayer < 0 || currentPlayer >= players.Count) {
                currentPlayer = dir == 1 ? 0 : players.Count - 1;
            }
        }


        string GetInput(string prompt) {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public CardColor ColorInput(string prompt) {
            while (true) {
                string input = GetInput(prompt);
                foreach (CardColor c in typeof(CardColor).GetEnumValues()) if (c.ToString() == input && input != "Wild") return c;
            }
        }

        void FuncCards(CardType c) {
            switch (c) {
                case CardType.DrawTwo:
                    for (int i = 0; i < 2; i++) {
                        players[Iterate((currentPlayer))].DealToHand(cards.Draw());
                    }
                    break;
                case CardType.DrawFour:
                    for (int i = 0; i < 4; i++) {
                        players[Iterate((currentPlayer))].DealToHand(cards.Draw());
                        nClr = ColorInput("New Color: ");
                    }
                    break;
                case CardType.Reverse:
                    dir *= -1;
                    break;
                case CardType.Skip:
                    Iterate();
                    break;
                case CardType.Wild:
                    nClr = ColorInput("New Color: ");
                    break;
                default:
                    string[] arr = new string[] { "one", "two", "three" };
                    Console.WriteLine(arr[3]);
                    //spice
                    break;
            }
        }

        public void GenerateDeck() {
            Array colors = Enum.GetValues(typeof(CardColor));
            Array types = Enum.GetValues(typeof(CardType));

            foreach (CardColor color in colors) {
                foreach (CardType type in types) {
                    if (color == CardColor.Wild && (type == CardType.Wild || type == CardType.DrawFour)) {
                        cards.Add(new Card(color, type));
                    } else if (color != CardColor.Wild && type != CardType.Wild && type != CardType.DrawFour) {
                        cards.Add(new Card(color, type));
                    }
                }
            }
        }
    }
}
