using System;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Renderers;
using Microsoft.Xna.Framework.Graphics;

namespace Dodger.MonoGame.Renderers
{
    public class HealthRenderer : IHealthRenderer
    {
        private readonly SpriteBatch _spriteBatch;

        public HealthRenderer(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
        }

        public void Render(IPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            
            throw new 
                NotImplementedException();
        }
    }
}