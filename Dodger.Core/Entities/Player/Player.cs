using System;
using Dodger.Core.Entities.Components.Health;
using Dodger.Core.Entities.Components.MovementComponent;
using Dodger.Core.Entities.Components.PhysicsComponent;
using Dodger.Core.Entities.Components.Score;
using Dodger.Core.Entities.World;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.Player
{
    public class Player : IPlayer
    {
        public Player(IPhysicsComponent physicsComponent, IMovementComponent movementComponent)
        {
            PhysicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            MovementComponent = movementComponent ?? throw new ArgumentNullException(nameof(movementComponent));
        }
        
        public void Update(IWorld world)
        {
            MovementComponent.Update(world);
        }

        public Score Score { get; set; } = new Score();
        public Health Health { get; set; } = new Health(5);
        public IPhysicsComponent PhysicsComponent { get; }
        public IMovementComponent MovementComponent { get; }
    }
}