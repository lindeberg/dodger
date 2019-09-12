using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities
{
    public class Player : InteractingObject
    {
        public Player(Point location, Size size) : base(location, size, "player.png")
        {
        }

        public Score Score { get; set; } = new Score();
    }
}