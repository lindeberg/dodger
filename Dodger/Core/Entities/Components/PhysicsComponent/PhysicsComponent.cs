using System;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.Components.PhysicsComponent
{
    public  class PhysicsComponent : IPhysicsComponent
    {
        public event EventHandler LocationChanged;
        
        public PhysicsComponent(Point location, Size size)
        {
            Location = location;
            Size = size;
        }
        private Point _location;

        public Point Location
        {
            get => _location;
            set
            {
                if (value == _location)
                    return;

                _location = value;

                LocationChanged?.Invoke(this, null);
            }
        }

        public Size Size { get; set; }

        public void Update(IInteractingGameObject gameObject)
        {
            
        }
    }
}