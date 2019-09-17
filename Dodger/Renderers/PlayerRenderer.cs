using System;
using System.Linq;
using System.Windows.Forms;
using Dodger.Controls.Player;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Renderers;
using Dodger.Core.ValueObjects;
using Point = System.Drawing.Point;

namespace Dodger.Renderers
{
    public class PlayerRenderer : IPlayerRenderer
    {
        private readonly MainForm _form;

        public PlayerRenderer(MainForm form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
        }

        public void Render(IPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));

            var pictureBox = GetPictureBox();

            if (pictureBox == null)
            {
                AddPictureBox(player);
            }
            else
            {
                RenderPictureBox(player, pictureBox);
            }
        }

        private void AddPictureBox(IPlayer player)
        {
            var size = new Size(player.PhysicsComponent.Size.Width, player.PhysicsComponent.Size.Height);
            var location = new Core.ValueObjects.Point(player.PhysicsComponent.Location.X, player.PhysicsComponent.Location.Y);
            var pictureBox = new PlayerPictureBox(size, location);

            _form.Controls.Add(pictureBox);
        }

        private PictureBox GetPictureBox()
        {
            return _form
                .Controls
                .OfType<PictureBox>()
                .SingleOrDefault(x => x.Name == "playerPictureBox");
        }

        private void RenderPictureBox(IPlayer player, PictureBox pictureBox)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (pictureBox == null) throw new ArgumentNullException(nameof(pictureBox));

            pictureBox.Location = new Point(player.PhysicsComponent.Location.X, player.PhysicsComponent.Location.Y);
        }
    }
}