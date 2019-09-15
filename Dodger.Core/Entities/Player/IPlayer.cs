using Dodger.Core.Entities.Components.MovementComponent;
using Dodger.Core.Entities.Components.PhysicsComponent;
using Dodger.Core.Entities.World;

namespace Dodger.Core.Entities.Player
{
    public interface IPlayer
    {
        void Update(IWorld world);
        Score Score { get; set; }
        IPhysicsComponent PhysicsComponent { get; }
        IMovementComponent MovementComponent { get; }
    }
}