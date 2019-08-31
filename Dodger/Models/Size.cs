namespace Dodger.Models
{
    public struct Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public readonly int Width;
        public readonly int Height;
    }
}