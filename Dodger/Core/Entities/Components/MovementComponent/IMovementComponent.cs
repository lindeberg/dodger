using Dodger.Core.Entities.World;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities.Components.MovementComponent
{
    public interface IMovementComponent
    {
        int MovementSpeed { get; set; }
        Direction? CurrentDirection { get; }
        void Move(IWorld world);
        void StopMoving();
        void SetDirection(Direction direction);
        void Update(IWorld world);
    }
}