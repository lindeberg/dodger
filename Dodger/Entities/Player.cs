using System;
using Dodger.Models;

namespace Dodger.Entities
{
    public class Player : InteractingObject
    {
        public Player(Point location) : base(location, new Size(70, 70), "player.png")
        {
        }

        public Score Score { get; set; } = new Score();
    }
}