using System.Windows.Forms;
using Dodger.Entities;
using Dodger.Models;

namespace Dodger.Factories
{
    public class PlayerFactory
    {
        public static Player CreatePlayer(PictureBox pictureBox)
        {
            var location = new Point(pictureBox.Location.X, pictureBox.Location.Y);

            var player = new Player(location);

            return player;
        }
    }
}