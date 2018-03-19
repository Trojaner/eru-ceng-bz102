using System;

namespace BZ102_4_2
{
    public class CardValueOptionAttribute : Attribute
    {
        public int Score { get; }
        public string Name { get; }

        public CardValueOptionAttribute(int score, string name)
        {
            Score = score;
            Name = name;
        }
    }
}