using System;
using Dodger.Models;

namespace Dodger.Entities
{
    public class Enemy : InteractingObject
    {
        public Enemy(Point location) : base(location, new Size(20, 20), "missile.png")
        {
        }

        public TimeInterval SpawnTimeInterval { get; set; } = new TimeInterval(10, 100);
    }
}