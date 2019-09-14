using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.World
{
    public class World : IWorld
    {
        public World(Size size)
        {
            Size = size;
        }
        public Size Size { get; set; }
    }
}