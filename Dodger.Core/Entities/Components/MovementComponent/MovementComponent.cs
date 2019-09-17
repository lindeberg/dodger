using System;
using Dodger.Core.Entities.Components.PhysicsComponent;
using Dodger.Core.Entities.World;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.Components.MovementComponent
{
    public abstract class MovementComponent : IMovementComponent
    {
        private readonly IPhysicsComponent _physicsComponent;

        public MovementComponent(int movementSpeed, IPhysicsComponent physicsComponent)
        {
            _physicsComponent = physicsComponent ?? throw new ArgumentNullException(nameof(physicsComponent));
            MovementSpeed = movementSpeed;
        }

        public void Move(IWorld world)
        {
            Point newLocation;

            switch (CurrentDirection)
            {
                case Direction.Left:
                    newLocation = new Point(_physicsComponent.Location.X - MovementSpeed, _physicsComponent.Location.Y);
                    break;
                case Direction.Right:
                    newLocation = new Point(_physicsComponent.Location.X + MovementSpeed, _physicsComponent.Location.Y);
                    break;
                case Direction.Up:
                    newLocation = new Point(_physicsComponent.Location.X, _physicsComponent.Location.Y - MovementSpeed);
                    break;
                case Direction.Down:
                    newLocation = new Point(_physicsComponent.Location.X, _physicsComponent.Location.Y + MovementSpeed);
                    break;
                default:
                    return;
            }

            if (newLocation.IsWithinDimensions(world.Size, _physicsComponent.Size))
                _physicsComponent.Location = newLocation;
        }

        public void StopMoving()
        {
            CurrentDirection = null;
        }

        public void SetDirection(Direction direction)
        {
            CurrentDirection = direction;
        }

        public void Update(IWorld world)
        {
            Move(world);
        }

        public int MovementSpeed { get; set; }
        public Direction? CurrentDirection { get; private set; }
    }
}