namespace Dodger.Core.Entities.Components.Score
{
    public class Score
    {
        public int Points { get; private set; }

        public void AddPoint()
        {
            Points++;
        }
    }
}