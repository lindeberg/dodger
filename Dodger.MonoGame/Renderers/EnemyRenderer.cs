using System;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Entities.Player;
using Dodger.Core.Graphics.Renderers;
using Dodger.Core.Persistance.Repositories.EnemyRepository;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dodger.MonoGame.Renderers
{
    public class EnemyRenderer : IEnemyRenderer
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly SpriteBatch _spriteBatch;
        private readonly ContentManager _contentManager;

        public EnemyRenderer(IEnemyRepository enemyRepository, SpriteBatch spriteBatch, ContentManager contentManager)
        {
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
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

        public void Remove(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
        }
        
        private Texture2D GetTexture()
        {
            return _contentManager.Load<Texture2D>("Images/missile");
        }

        private static Rectangle GetRectangle(Enemy enemy)
        {
            var point = new Point(enemy.PhysicsComponent.Location.X, enemy.PhysicsComponent.Location.Y);
            var size = new Point(enemy.PhysicsComponent.Size.Width, enemy.PhysicsComponent.Size.Height);
            return new Rectangle(point, size);
        }
    }
}