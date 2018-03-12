using System;
using System.Collections.Generic;
using System.Numerics;

namespace BZ102_2
{
    public class Segment : Entity
    {
        private readonly Snake _snake;
        public int Index { get; }

        public Vector2 PreviousPos { get; private set; }

        public Segment(Snake snake, int index)
        {
            _snake = snake;
            Index = index;
        }

        public Segment(int index)
        {
            if(!(this is Snake))
                throw new ArgumentException();
            Index = index;
        }

        protected override void OnPositionUpdate(Vector2 newPosition)
        {
            base.OnPositionUpdate(newPosition);
            PreviousPos = Position;
        }

        public override char Symbol => 'X';
    }

    public class Snake : Segment
    {
        public Snake() : base(0)
        {
            Segments.Add(this);
        }

        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                _score += value;
                Program.UpdateScore(this);
            }
        }
        public void Eat(Food food)
        {
            Score += food.Score;
            food.Destroy();
        }

        public List<Segment> Segments { get; } = new List<Segment>();
        
        
        public override void Draw()
        {
            base.Draw();

            foreach (var segment in Segments)
            {
                if (segment == this)
                    continue;

                segment.Draw();
            }
        }

        protected override void OnPositionUpdate(Vector2 newPosition)
        {
            base.OnPositionUpdate(newPosition);

            var food = Program.GetFoodAtPos(newPosition);
            if (food != null)
            {
                Eat(food);
                Program.CreateNewFood();
                Segments.Add(new Segment(this, Segments.Count));
            }
        }

        protected override void OnPostPositionUpdate()
        {
            foreach (var segment in Segments)
            {
                if (segment == this)
                    continue;

                segment.Position = Segments[segment.Index - 1].PreviousPos;
            }
        }
    }
}