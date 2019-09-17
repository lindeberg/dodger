using Dodger.Core.ValueObjects;

namespace Dodger.WinForms.Controls.Player
{
    public class PlayerPictureBox : PictureBox
    {
        public PlayerPictureBox(Size size, Point location, string imagePath ="player.png", string name = "playerPictureBox") : base(name, size, location, imagePath)
        {
        }
    }
}