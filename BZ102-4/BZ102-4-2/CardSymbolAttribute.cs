using System;

namespace BZ102_4_2
{
    public class CardSymbolAttribute : Attribute
    {
        public char Symbol { get; }

        public CardSymbolAttribute(char symbol)
        {
            Symbol = symbol;
        }
    }
}