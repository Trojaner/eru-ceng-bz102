using System;

namespace BZ102_4_2
{
    public class CardScoreAttribute : Attribute
    {
        public int Score { get; }

        public CardScoreAttribute(int score)
        {
            Score = score;
        }
    }
}