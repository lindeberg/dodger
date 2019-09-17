using Dodger.Core.Entities.Components.PhysicsComponent;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.Player.Components;
using Dodger.Core.Entities.World;
using Dodger.Core.ValueObjects;

namespace Dodger.Core.Factories
{
    public class PlayerFactory
    {
        public Player CreatePlayer(IWorld world)
        {
            const int movementSpeed = 5;
            var size = GetPlayerSize(world);

            var location = GetSpawnLocation(world, size);
            var physicsComponent = new PhysicsComponent(location, size);
            var movementComponent = new MovementComponent(movementSpeed, physicsComponent);

            return new Player(physicsComponent, movementComponent);
        }

        private Size GetPlayerSize(IWorld world)
        {
            var width = (int) (world.Size.Width * 0.1);
            return new Size(width, width);
        }

        private Point GetSpawnLocation(IWorld world, Size size)
        {
            var x = world.Size.Width / 2 - size.Width / 2;
            var y = world.Size.Height - size.Height;
            return new Point(x, y);
        }
    }
}