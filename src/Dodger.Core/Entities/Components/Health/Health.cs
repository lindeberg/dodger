using System;

namespace Dodger.Core.Entities.Components.Health
{
    public class Health
    {
        private uint _points;
        public event EventHandler Died;

        public Health(uint points)
        {
            Points = points;
        }

        public uint Points
        {
            get => _points;
            private set
            {
                _points = value;
                if (_points == 0)
                {
                    Died?.Invoke(this, null);
                }
            }
        }

        public bool IsAlive => Points > 0;

        public void LosePoint()
        {
            if (Points > 0)
                Points--;
        }
    }
}