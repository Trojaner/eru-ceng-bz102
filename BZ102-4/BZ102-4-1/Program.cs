using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace BZ102_2
{
    class Program
    {
        public static List<Snake> Snakes { get; } = new List<Snake> { new Snake() };
        public static List<Food> Foods { get; } = new List<Food>();

        public static bool Run { get; set; } = true;

        public static int Width => Console.WindowWidth;
        public static int Height => Console.WindowHeight; 
        public static int Left => Console.WindowLeft;
        public static int Top => Console.WindowTop;

        private static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            Console.Clear();
            Console.CursorVisible = false;

            var snake = Snakes.First();
            snake.Position = Vector2.One;
            snake.Draw();

            UpdateScore(snake);
            
            Thread inputThread = new Thread(InputLoop);
            inputThread.Start();

            CreateNewFood();
        }

        public static Food GetFoodAtPos(Vector2 pos1)
        {
            return Foods.FirstOrDefault(food => pos1 == food.Position);
        }

        static void InputLoop()
        {
            while (Run)
            {
                float speedModifier = 1;

                var key = Console.ReadKey(true);
                var snake = Snakes.First();

                foreach (var food in Foods)
                {
                    food.Draw();
                }

                UpdateScore(snake);

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        snake.Move(new Vector2(0, -1) * speedModifier);
                        break;

                    case ConsoleKey.A:
                        snake.Move(new Vector2(-1, 0) * speedModifier);
                        break;

                    case ConsoleKey.D:
                        snake.Move(new Vector2(1, 0) * speedModifier);
                        break;

                    case ConsoleKey.S:
                        snake.Move(new Vector2(0, 1) * speedModifier);
                        break;
                }
            }
        }

        public static Food CreateNewFood()
        {
            var score = Random.Next(1, 100);

            var pos = GetRandomPos();
            if (GetFoodAtPos(pos) != null)
                return CreateNewFood();

            Food food = new Food(score)
            {
                Position = GetRandomPos()
            };

            Foods.Add(food);
            food.Draw();

            return food;
        }

        public static Vector2 GetRandomPos()
        {
            return new Vector2(Random.Next(0, Width), Random.Next(0, Height));
        }

        public static void UpdateScore(Snake snake)
        {
            Console.Title = "Score: " + snake.Score;
        }
    }
}
