using System;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Graphics.Renderers;
using Dodger.Core.Persistance.Repositories.EnemyRepository;

namespace Dodger.MonoGame.Renderers
{
    public class EnemyRenderer : IEnemyRenderer
    {
        private readonly IEnemyRepository _enemyRepository;

        public EnemyRenderer(IEnemyRepository enemyRepository)
        {
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
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