namespace Dodger.Core.ValueObjects
{
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public readonly int X;
        public readonly int Y;

        public bool IsWithinDimensions(Size mapSize, Size objectSize)
        {
            return X >= 0 &&
                   Y >= 0 &&
                   X <= mapSize.Width - objectSize.Width   &&
                   Y <= mapSize.Height - objectSize.Height;
        }
        
        public static bool operator ==(Point point1, Point point2)
        {
            return point1.Equals(point2);
        }
        public static bool operator !=(Point point1, Point point2)
        {
            return !point1.Equals(point2);
        }
        
        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }
        
        public override bool Equals(object obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}