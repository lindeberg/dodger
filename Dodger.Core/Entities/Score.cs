using System;

namespace Dodger.Core.Entities
{
    public class Score
    {
        private int _points;

        public int Points
        {
            get => _points;
            private set
            {
                _points = value;
                ScoreChanged?.Invoke(this, new ScoreChangedEventArgs(_points));
            }
        }

        public event EventHandler<ScoreChangedEventArgs> ScoreChanged;

        public void AddPoint()
        {
            Points++;
        }
    }

    public class ScoreChangedEventArgs
    {
        public ScoreChangedEventArgs(int points)
        {
            Points = points;
        }
        
        public int Points { get; }
    }
}