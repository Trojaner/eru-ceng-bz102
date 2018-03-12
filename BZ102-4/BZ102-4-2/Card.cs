namespace BZ102_4_2
{
    class Card
    {
        public Card(CardType type, CardValue value)
        {
            Type = type;
            Value = value;
        }

        public CardType Type { get; set; }
        public CardValue Value { get; set; }

    }
}