using System;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dodger.MonoGame.Renderers
{
    public class EnemyRenderer : IEnemyRenderer
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly ContentManager _contentManager;

        public EnemyRenderer(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
            _contentManager = contentManager ?? throw new ArgumentNullException(nameof(contentManager));
        }
        public void Render(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            
            var texture = GetTexture();
            var rectangle = GetRectangle(enemy);
            
            _spriteBatch.Draw(texture, rectangle, Color.White);
        }
        
        private Texture2D GetTexture()
        {
            return _contentManager.Load<Texture2D>(Content.AssetNames.Enemy.Texture);
        }

        private static Rectangle GetRectangle(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            
            var point = new Point(enemy.PhysicsComponent.Location.X, enemy.PhysicsComponent.Location.Y);
            var size = new Point(enemy.PhysicsComponent.Size.Width, enemy.PhysicsComponent.Size.Height);
            return new Rectangle(point, size);
        }
    }
}