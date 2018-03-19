using System.Linq;

namespace BZ102_4_2
{
    static class CardValueExntesions
    {
        public static int GetScore(this CardValue value)
        {
            var type = typeof(CardValue);
            var memInfo = type.GetMember(value.ToString());
            var cardAttrbute = (CardValueOptionAttribute) memInfo[0].GetCustomAttributes(typeof(CardValueOptionAttribute), false).First();
            return cardAttrbute.Score;
        }

        public static string GetName(this CardValue value)
        {
            var type = typeof(CardValue);
            var memInfo = type.GetMember(value.ToString());
            var cardAttrbute = (CardValueOptionAttribute)memInfo[0].GetCustomAttributes(typeof(CardValueOptionAttribute), false).First();
            return cardAttrbute.Name;
        }
    }
}