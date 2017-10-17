using System;
using System.Collections.Generic;

namespace Uno {
    class Game {
        private Deck<Card> cards;
        public List<Player> players;
        private Player[] winners;
        private int currentPlayer;
        private int nextPlace;
        private int dir;
        private CardColor newColor;

        public Game() {
            cards = new Deck<Card>();
            players = new List<Player>();
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
            GenerateDeck();
            cards.Shuffle();
            cards.Play(cards.Draw());

            int playerCount = int.Parse(GetInput("How many players?: "));
            for (int i = 1; i <= playerCount; i++) {
                string playerName = GetInput("Player " + i + " name: ");
                players.Add(new Player(playerName));
            }

            winners = new Player[playerCount];

            foreach (Player p in players) {
                for (int i = 0; i < 7; i++) {
                    p.DealToHand(cards.Draw());
                }
            }
        }

        void Turn() {
            Console.Clear();
            Player player = players[currentPlayer];

            GetInput($"Press enter to change to {player.name}'s turn...");
            Console.Clear();

            int drawAmnt = 0;
            while (!player.CanPlay(cards.Top)) {
                player.DealToHand(cards.Draw());
                drawAmnt++;
            }

            if (drawAmnt > 0) {
                Console.WriteLine($"{player.name} picked up {drawAmnt} cards");
            }

            Card topCard = cards.Top.type == CardType.Wild ? new Card(newColor, CardType.Wild) : cards.Top;
            Card playedCard = player.ChooseCard(topCard);

            cards.Play(playedCard);
            HandleCard(playedCard.type);

            if (player.HasWon()) {
                players.Remove(player);
                winners[nextPlace - 1] = player;
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

        CardColor ColorInput(string prompt) {
            string input = "";
            CardColor color;
            do {
                input = GetInput(prompt);
            } while (!Enum.TryParse(input, true, out color));

            return color;
        }

        void HandleCard(CardType c) {
            switch (c) {
                case CardType.DrawTwo:
                    for (int i = 0; i < 2; i++) {
                        players[Iterate((currentPlayer))].DealToHand(cards.Draw());
                    }
                    break;
                case CardType.DrawFour:
                    for (int i = 0; i < 4; i++) {
                        players[Iterate((currentPlayer))].DealToHand(cards.Draw());
                    }
                    newColor = ColorInput("New Color: ");
                    break;
                case CardType.Reverse:
                    dir *= -1;
                    break;
                case CardType.Skip:
                    Iterate();
                    break;
                case CardType.Wild:
                    newColor = ColorInput("New Color: ");
                    break;
            }
        }

        public void GenerateDeck() {
            Array colors = Enum.GetValues(typeof(CardColor));
            Array types = Enum.GetValues(typeof(CardType));
            for (int i = 0; i < 2; i++) {
                foreach (CardColor color in colors) {
                    foreach (CardType type in types) {
                        if (color != CardColor.Wild && !(type == CardType.Wild || type == CardType.DrawFour)) {
                            cards.Add(new Card(color, type));
                        }
                    }
                }
            }

            for (int i = 0; i < 4; i++) {
                cards.Add(new Card(CardColor.Wild, CardType.Wild));
                cards.Add(new Card(CardColor.Wild, CardType.DrawFour));
            }
        }
    }
}

