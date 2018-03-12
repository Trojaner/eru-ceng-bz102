namespace BZ102_2
{
    public class Food : Entity
    {
        public int Score { get; }

        public Food(int score)
        {
            Score = score;
        }

        public override char Symbol => 'O';

        public override void Destroy()
        {
            base.Destroy();
            Program.Foods.Remove(this);
        }
    }
}