namespace Dodger.Core.ValueObjects
{
    public struct TimeInterval
    {
        public TimeInterval(int min, int max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// In ms
        /// </summary>
        public int Min { get; set; }
        
        /// <summary>
        /// In ms
        /// </summary>
        public int Max { get; set; }
    }
}