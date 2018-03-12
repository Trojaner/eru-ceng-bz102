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
            while(DrawAndDisplayCard(cards) != null)
                ;

            Console.WriteLine("No cards left");
            Console.ReadKey();
        }

        static Card  DrawAndDisplayCard(Cards cards)
        {
            var card = cards.DrawCard();
            Console.WriteLine($"Card retrieved: {card.Type} - {card.Value} (Score: {card.Value.GetScore()})");
            Console.ReadKey(true);
            return card;
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
