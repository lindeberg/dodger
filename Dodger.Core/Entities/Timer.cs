using System;

namespace Dodger.Core.Entities
{
    public class Timer
    {
        public event EventHandler Tick;

        public void InvokeTick()
        {
            Tick?.Invoke(this, null);
        }
    }
}