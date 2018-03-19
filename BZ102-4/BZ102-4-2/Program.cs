using System;
using System.Collections.Generic;
using System.Linq;

namespace BZ102_4_2
{
    class Program
    {
        public static List<Player> Players = new List<Player>();
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DrawLine();
            WriteCentered("BLACK JACK", ConsoleColor.Cyan);
            DrawLine();

            Console.WriteLine();

            Cards cards = new Cards(52);
            FillDeck(cards);
            cards.Shuffle();

            getPlayers:
            Console.WriteLine("Enter player amount: ");
            if (!int.TryParse(Console.ReadLine(), out int players))
                goto getPlayers;

            for (int i = 0; i < players; i++)
            {
                Console.WriteLine($"Enter {i + 1}. player name: ");
                Players.Add(new Player
                {
                    Name = Console.ReadLine(),
                    Score = 0
                });
            }

            int currentPlayerId = 0;
            Dictionary<int, int> currentPlayerScores = new Dictionary<int, int>();
            while (true)
            {
                if (currentPlayerId == Players.Count || currentPlayerScores.Count == 1)
                {
                    var winnerId = currentPlayerScores.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                    var winner = Players.ElementAt(winnerId);

                    winner.Score++;

                    WriteLineColored($"{winner.Name} wins! (Total score: {winner.Score})", ConsoleColor.DarkGreen);
                    WriteLineColored("Scores:", ConsoleColor.Blue);
                    foreach (var p in Players)
                    {
                        Console.WriteLine("    " + p.Name + ": " + p.Score);
                    }

                    currentPlayerScores.Clear();
                    currentPlayerId = 0;
                    continue;
                }

                if (currentPlayerScores.Count == 0)
                {
                    foreach (var p in Players)
                    {
                        currentPlayerScores.Add(Players.IndexOf(p), 0);
                    }
                }

                var player = Players.ElementAt(currentPlayerId);
                WriteLineColored(player.Name + " is playing.", ConsoleColor.Cyan);

                drawCard:
                Card card = cards.DrawCard();

                currentPlayerScores[currentPlayerId] += card.Value.GetScore();
                Console.Write("Drawed card: ");
                WriteColored(card.Type.GetSymbol().ToString(), ConsoleColor.Blue);
                Console.Write(" ");
                WriteColored(card.Value.GetName(), ConsoleColor.Green);
                Console.Write("  (value: ");
                WriteColored(card.Value.GetScore().ToString(), ConsoleColor.DarkGreen);
                Console.Write(", total value: ");
                WriteColored(currentPlayerScores[currentPlayerId].ToString(), ConsoleColor.DarkMagenta);
                Console.WriteLine(")");

                if (currentPlayerScores[currentPlayerId] > 21)
                {
                    currentPlayerScores.Remove(currentPlayerId);
                    WriteLineColored($"Overflow. {player.Name} is out.", ConsoleColor.DarkRed);
                }
                else
                {
                    WriteLineColored("Draw another card? [Y/N]", ConsoleColor.Yellow);

                    readkey:
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Y)
                        goto drawCard;
                    if (key.Key != ConsoleKey.N)
                        goto readkey;
                }
                currentPlayerId++;
            }
        }

        public static void DrawLine()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write("-");
            Console.WriteLine();
        }

        public static void WriteCentered(string text, ConsoleColor color)
        {
            for (int i = 0; i < (Console.WindowWidth / 2) - text.Length / 2; i++)
                Console.Write(" ");

            WriteLineColored(text, color);
        }

        public static void WriteLineColored(string message, ConsoleColor color)
        {
            var tmp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = tmp;
        }

        public static void WriteColored(string message, ConsoleColor color)
        {
            var tmp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = tmp;
        }

        static void FillDeck(Cards cards)
        {
            foreach (CardType type in Enum.GetValues(typeof(CardType)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    cards.AddCard(new Card(type, value));
                }
            }
        }
    }
}
