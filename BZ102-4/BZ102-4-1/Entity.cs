using System;
using System.Numerics;

namespace BZ102_2
{
    public abstract class Entity
    {
        private Vector2 _position;

        public Vector2 Position
        {
            get => _position;
            set
            {
                if (!OnPrePositionUpdate(Position))
                    return;

                Clear();

                if (value.X >= Program.Width)
                    value.X = Program.Left;

                if (value.X < Program.Left)
                    value.X = Program.Width - 1;

                if (value.Y >= Program.Height)
                    value.Y = Program.Top;

                if (value.Y < Program.Top)
                    value.Y = Program.Height - 1;

                OnPositionUpdate(value);
                _position = value;
                OnPostPositionUpdate();
            }
        }

        protected virtual bool OnPrePositionUpdate(Vector2 position)
        {
            return true;
        }

        public virtual void Draw()
        {
            Draw(Position);
        }

        public virtual void Draw(Vector2 pos)
        {
            Clear();
            Console.SetCursorPosition((int)pos.X, (int)pos.Y);
            Console.Write(Symbol);
        }

        public virtual void Clear()
        {
            Console.SetCursorPosition((int)Position.X, (int)Position.Y);
            Console.Write(" ");
        }

        public abstract char Symbol { get; }

        public void Move(Vector2 units)
        {
            Position += units;
            Draw();
        }

        protected virtual void OnPositionUpdate(Vector2 newPosition)
        {

        }

        protected virtual void OnPostPositionUpdate()
        {

        }

        public virtual void Destroy()
        {
            Clear();
        }
    }
}