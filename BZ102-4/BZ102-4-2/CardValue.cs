namespace BZ102_4_2
{
    enum CardValue
    {
        [CardValueOption(2, "2")]
        C2,
        [CardValueOption(3, "3")]
        C3,
        [CardValueOption(4, "4")]
        C4,
        [CardValueOption(5, "5")]
        C5,
        [CardValueOption(6, "6")]
        C6,
        [CardValueOption(7, "7")]
        C7,
        [CardValueOption(8, "8")]
        C8,
        [CardValueOption(9, "9")]
        C9,
        [CardValueOption(10, "10")]
        C10,
        [CardValueOption(10, "Joker")]
        Joker,
        [CardValueOption(10, "Queen")]
        Queen,
        [CardValueOption(10, "King")]
        King,
        [CardValueOption(11, "Ace")]
        Ace
    }
}