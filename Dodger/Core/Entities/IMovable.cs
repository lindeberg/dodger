using System;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities
{
    public interface IMovable
    {
        Point Location { get; }
        int MovementSpeed { get; set; }
        Direction? CurrentDirection { get; }
        event EventHandler Moved;
        void Move(Size space);
        void StopMoving();
        void SetDirection(Direction direction);
    }
}