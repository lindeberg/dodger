using System.Windows.Forms;
using Dodger.Core.Entities.Components.PhysicsComponent;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.Player.Components;
using Dodger.Core.ValueObjects;

namespace Dodger.Factories
{
    public class PlayerFactory
    {
        public static Player CreatePlayer(PictureBox pictureBox)
        {
            var location = new Point(pictureBox.Location.X, pictureBox.Location.Y);
            var size = new Size(pictureBox.Size.Width, pictureBox.Size.Height);
            
            var physicsComponent = new PhysicsComponent(location, size);
            var movementComponent = new MovementComponent(5, physicsComponent);
            
            var player = new Player(physicsComponent, movementComponent);

            return player;
        }
    }
}