using System;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Graphics.Renderers;
using Dodger.Core.Persistance.Repositories.EnemyRepository;
using Microsoft.Xna.Framework.Graphics;

namespace Dodger.MonoGame.Renderers
{
    public class EnemyRenderer : IEnemyRenderer
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly SpriteBatch _spriteBatch;

        public EnemyRenderer(IEnemyRepository enemyRepository, SpriteBatch spriteBatch)
        {
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            _spriteBatch = spriteBatch ?? throw new ArgumentNullException(nameof(spriteBatch));
        }
        public void Render(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            throw new NotImplementedException();
        }

        public void Remove(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            throw new NotImplementedException();
        }
    }
}