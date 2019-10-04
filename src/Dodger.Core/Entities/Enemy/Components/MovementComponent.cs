using Dodger.Core.Entities.Components.PhysicsComponent;

namespace Dodger.Core.Entities.Enemy.Components
{
    public class MovementComponent : Entities.Components.MovementComponent.MovementComponent
    {
        public MovementComponent(int movementSpeed, IPhysicsComponent physicsComponent) : base(movementSpeed, physicsComponent)
        {
            MovementSpeed = 1;
        }
    }
}