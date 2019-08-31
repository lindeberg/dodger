namespace Dodger.Models
{
    public class Score
    {
        public int Points { get; set; }

        public void AddPoint()
        {
            Points++;
        }
    }
}