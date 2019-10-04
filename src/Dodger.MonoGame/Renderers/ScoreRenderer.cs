using System;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dodger.MonoGame.Renderers
{
    public class ScoreRenderer : IScoreRenderer
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly ContentManager _contentManager;

        public ScoreRenderer(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
            _contentManager = contentManager ?? throw new ArgumentNullException(nameof(contentManager));
        }
        
        public void Render(IPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            
            var spriteFont = GetSpriteFont();
            var scoreText = "Score:" + player.Score.Points;
            var location = GetPosition();
            var color = Color.Black;
            
            _spriteBatch.DrawString(spriteFont, scoreText, location, color);
        }

        private static Vector2 GetPosition()
        {
            return new Vector2(50, 100);
        }

        private SpriteFont GetSpriteFont()
        {
            return _contentManager.Load<SpriteFont>(Content.AssetNames.Score.Font);
        }
    }
}