using System;
using Dodger.Core.Entities.Components.MovementComponent;
using Dodger.Core.Entities.Components.PhysicsComponent;
using Dodger.Core.Entities.World;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.Enemy
{
    public class Enemy 
    {
        public Enemy(IMovementComponent movementComponent, IPhysicsComponent physicsComponent)
        {
            MovementComponent = movementComponent ?? throw new ArgumentNullException(nameof(movementComponent));
            PhysicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));

            MovementComponent.SetDirection(Direction.Down);
        }

        public void Update(IWorld world)
        {
            MovementComponent.Update(world);
        }

        public Guid Id { get; } = Guid.NewGuid();
        public IMovementComponent MovementComponent { get; }
        public IPhysicsComponent PhysicsComponent { get; }
    }
}