using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Handlers;

namespace Dodger.Graphics.Handlers
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
            
            SetLocation(player);
        }

        private void SetLocation(IPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));

            var pictureBox = _form
                .Controls
                .OfType<PictureBox>()
                .SingleOrDefault(x => x.Name == "playerPictureBox");
            
            if(pictureBox == null)
                return;
            
            pictureBox.Location = new Point(player.PhysicsComponent.Location.X, player.PhysicsComponent.Location.Y);
        }
    }
}