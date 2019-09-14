using System.Windows.Forms;
using Dodger.Core.ValueObjects;
using PictureBox = Dodger.Controls.PictureBox;

namespace Dodger.Core.Entities.Player.Controls
{
    public class PlayerPictureBox : PictureBox
    {
        public PlayerPictureBox(string name, Size size, Point location, string imagePath) : base(name, size, location, imagePath)
        {
            
        }
    }
}