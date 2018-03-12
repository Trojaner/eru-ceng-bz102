using System;

namespace BZ102_4_2
{
    class Program
    {
        static void Main()
        {
            Cards cards = new Cards(52);
            FillDeck(cards);
            cards.Shuffle();
            var card = cards.DrawCard();

            Console.WriteLine($"Card retrieved: {card.Type} - {card.Value} (Score: {card.Value.GetScore()})");
            Console.ReadKey(true);
            Main();
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
