using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.Components.PhysicsComponent
{
    public class PhysicsComponent : IPhysicsComponent
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

        public bool IsCollidingWith(IPhysicsComponent gameObject)
        {
            return Location.X < gameObject.Location.X + gameObject.Size.Width &&
                   Location.X + Size.Width > gameObject.Location.X &&
                   Location.Y < gameObject.Location.Y + gameObject.Size.Height &&
                   Location.Y + Size.Height > gameObject.Location.Y;
        }
    }
}