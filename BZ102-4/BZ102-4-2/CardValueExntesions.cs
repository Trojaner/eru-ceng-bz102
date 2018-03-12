using System.Linq;

namespace BZ102_4_2
{
    static class CardValueExntesions
    {
        public static int GetScore(this CardValue value)
        {
            var type = typeof(CardValue);
            var memInfo = type.GetMember(value.ToString());
            var cardAttrbute = (CardScoreAttribute) memInfo[0].GetCustomAttributes(typeof(CardScoreAttribute), false).First();
            return cardAttrbute.Score;
        }
    }
}