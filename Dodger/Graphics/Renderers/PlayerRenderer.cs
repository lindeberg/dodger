using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Handlers;
using Dodger.Core.Graphics.Renderers;

namespace Dodger.Graphics.Renderers
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
            
            if(pictureBox == null)
                return;
            
            SetLocation(player, pictureBox);
        }

        private PictureBox GetPictureBox()
        {
            return _form
                .Controls
                .OfType<PictureBox>()
                .SingleOrDefault(x => x.Name == "playerPictureBox");
        }

        private void SetLocation(IPlayer player, PictureBox pictureBox)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (pictureBox == null) throw new ArgumentNullException(nameof(pictureBox));

            pictureBox.Location = new Point(player.PhysicsComponent.Location.X, player.PhysicsComponent.Location.Y);
        }
    }
}