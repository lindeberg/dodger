using System.Windows.Forms;
using Dodger.Core.Entities;
using Dodger.Core.ValueObjects;

namespace Dodger.Factories
{
    public class PlayerFactory
    {
        public static Player CreatePlayer(PictureBox pictureBox)
        {
            var location = new Point(pictureBox.Location.X, pictureBox.Location.Y);
            var size = new Size(pictureBox.Size.Width, pictureBox.Size.Height);
            var player = new Player(location, size);

            return player;
        }
    }
}