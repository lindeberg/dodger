using System;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities
{
    public abstract class InteractingObject : IInteractingObject
    {
        private Point _location;

        public event EventHandler Moved;

        public InteractingObject(Point location, Size size, string imagePath)
        {
            if (string.IsNullOrWhiteSpace(value: imagePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(imagePath));

            Size = size;
            ImagePath = imagePath;
            _location = location;
        }

        public int MovementSpeed { get; set; } = 5;

        public Point Location
        {
            get => _location;
            private set
            {
                if (value == _location)
                    return;

                _location = value;

                Moved?.Invoke(this, null);
            }
        }

        public string ImagePath { get; }
        public Size Size { get; set; }

        public Direction? CurrentDirection { get; private set; }

        public void Move(Size space)
        {
            Point newLocation;

            switch (CurrentDirection)
            {
                case Direction.Left:
                    newLocation = new Point(Location.X - MovementSpeed, Location.Y);
                    break;
                case Direction.Right:
                    newLocation = new Point(Location.X + MovementSpeed, Location.Y);
                    break;
                case Direction.Up:
                    newLocation = new Point(Location.X, Location.Y - MovementSpeed);
                    break;
                case Direction.Down:
                    newLocation = new Point(Location.X, Location.Y + MovementSpeed);
                    break;
                default:
                    return;
            }

            if (newLocation.IsWithinDimensions(space, Size))
                Location = newLocation;
        }

        public void StopMoving()
        {
            CurrentDirection = null;
        }

        public void SetDirection(Direction direction)
        {
            CurrentDirection = direction;
        }
        
    }
}