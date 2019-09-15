using System;
using Dodger.Core.Entities.Components.GraphicsComponent;
using Dodger.Core.Entities.Components.MovementComponent;
using Dodger.Core.Entities.Components.PhysicsComponent;
using Dodger.Core.Entities.World;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.Enemy
{
    public class Enemy 
    {
        public Enemy(IMovementComponent movementComponent, IPhysicsComponent physicsComponent, IGraphicsComponent graphicsComponent)
        {
            MovementComponent = movementComponent ?? throw new ArgumentNullException(nameof(movementComponent));
            PhysicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            GraphicsComponent = graphicsComponent ?? throw new ArgumentNullException(nameof(graphicsComponent));

            MovementComponent.SetDirection(Direction.Down);
            ConfigureEventHandlers();
        }

        public void Update(IWorld world)
        {
            MovementComponent.Update(world);
        }

        public Guid Id { get; } = Guid.NewGuid();
        public IMovementComponent MovementComponent { get; }
        public IPhysicsComponent PhysicsComponent { get; }
        public IGraphicsComponent GraphicsComponent { get; }
        
        private void ConfigureEventHandlers()
        {
            PhysicsComponent.LocationChanged += (sender, e) => GraphicsComponent.Update(PhysicsComponent);
        }
    }
}