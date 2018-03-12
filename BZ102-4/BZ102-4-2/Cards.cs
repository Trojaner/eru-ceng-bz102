using System;
using System.Linq;

namespace BZ102_4_2
{
    class Cards
    {
        private int _drawIndex = -1;

        private readonly int _capacity;
        private readonly Card[] _deck;
        private readonly Random _rnd = new Random();

        private int _index;

        public Cards(int capacity)
        {
            _capacity = capacity;
            _deck = new Card[capacity];
        }

        public void AddCard(Card card)
        {
            if (_index == _capacity)
                return;

            _deck[_index] = card;
            _index++;
            _drawIndex++;
        }

        public void Shuffle()
        {
            var suffledArray = _deck.OrderBy(x => _rnd.Next()).ToArray();
            Array.Copy(suffledArray, _deck, suffledArray.Length);
        }

        public Card DrawCard()
        {
            var card = _deck[_drawIndex];
            _drawIndex--;

            if(_drawIndex < 0)
                throw new Exception("No cards left!");

            if(card == null)
                throw new Exception();

            return card;
        }

        public void Reset()
        {
            _drawIndex = _capacity - 1;
        }
    }
}