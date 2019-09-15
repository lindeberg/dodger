using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.Components.PhysicsComponent
{
    public  class PhysicsComponent : IPhysicsComponent
    {
        public PhysicsComponent(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        public Point Location { get; set; }

        public Size Size { get; set; }

        public void Update(IInteractingGameObject gameObject)
        {
            
        }
    }
}