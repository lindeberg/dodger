using System;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dodger.MonoGame.Renderers
{
    public class PlayerRenderer : IPlayerRenderer
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly ContentManager _contentManager;

        public PlayerRenderer(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
            _contentManager = contentManager ?? throw new ArgumentNullException(nameof(contentManager));
        }
        
        public void Render(IPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));

            var texture = GetTexture();
            var rectangle = GetRectangle(player);
            
            _spriteBatch.Draw(texture, rectangle, Color.White);
        }

        private Texture2D GetTexture()
        {
            return _contentManager.Load<Texture2D>(Content.AssetNames.Player.Texture);
        }

        private static Rectangle GetRectangle(IPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            
            var point = new Point(player.PhysicsComponent.Location.X, player.PhysicsComponent.Location.Y);
            var size = new Point(player.PhysicsComponent.Size.Width, player.PhysicsComponent.Size.Height);
            return new Rectangle(point, size);
        }
    }
}