namespace Dodger.Core.Helpers
{
    public static class Random
    {
        private static readonly System.Random random = new System.Random();
        private static readonly object SyncLock = new object();

        public static int Next(int min, int max)
        {
            lock (SyncLock)
            {
                return random.Next(min, max);
            }
        }
    }
}