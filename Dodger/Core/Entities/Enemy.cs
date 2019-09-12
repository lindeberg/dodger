using System;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities
{
    public class Enemy : InteractingObject
    {
        public Enemy(Point location) : base(location, new Size(20, 20), "missile.png")
        {
            SetDirection(Direction.Down);
        }

        public Guid Id { get; } = Guid.NewGuid();
    }
}