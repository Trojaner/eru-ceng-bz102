using System.Linq;

namespace BZ102_4_2
{
    enum CardType
    {
        [CardSymbol('♥')]
        Heart,
        [CardSymbol('♦')]
        Diamond,
        [CardSymbol('♣')]
        Club,
        [CardSymbol('♠')]
        Spade
    }

    static class CardTypeExtensions
    {
        public static char GetSymbol(this CardType value)
        {
            var type = typeof(CardType);
            var memInfo = type.GetMember(value.ToString());
            var cardAttrbute = (CardSymbolAttribute)memInfo[0].GetCustomAttributes(typeof(CardSymbolAttribute), false).First();
            return cardAttrbute.Symbol;
        }
    }
}