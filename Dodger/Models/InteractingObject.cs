using System;
using Dodger.Annotations;

namespace Dodger.Models
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
        
        public int MovementSpeed { get; set; } = 10;

        public Point Location
        {
            get => _location;
            private set
            {
                _location = value;
                Moved?.Invoke(this, null);
            }
        }

        public string ImagePath { get; }
        public Size Size { get; }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    Location = new Point(Location.X - MovementSpeed, Location.Y);
                    break;
                case Direction.Right:
                    Location = new Point(Location.X + MovementSpeed, Location.Y);
                    break;
                case Direction.Up:
                    Location = new Point(Location.X, Location.Y - MovementSpeed);
                    break;
                case Direction.Down:
                    Location = new Point(Location.X, Location.Y + MovementSpeed);
                    break;
                default:
                    return;
            }
        }

    }
}