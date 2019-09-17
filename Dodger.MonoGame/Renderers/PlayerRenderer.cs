using System;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Renderers;

namespace Dodger.MonoGame.Renderers
{
    public class PlayerRenderer : IPlayerRenderer
    {
        public void Render(IPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            throw new NotImplementedException();
        }
    }
}