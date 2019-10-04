using System;
using System.Linq;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Entities.World;
using Dodger.Core.Persistance.Repositories.EnemyRepository;

namespace Dodger.Core.Handlers
{
    public class EnemyDisposer : IEnemyDisposer
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly IWorld _world;

        public EnemyDisposer(IEnemyRepository enemyRepository, IWorld world)
        {
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            _world = world ?? throw new ArgumentNullException(nameof(world));
        }

        public void DisposeEnemies()
        {
            var enumerable = _enemyRepository.GetAll().ToList();
            
            foreach (var enemy in enumerable)
            {
                DisposeEnemy(enemy);
            }
        }

        public void DisposeEnemy(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));

            if (enemy.PhysicsComponent.Location.IsWithinDimensions(_world.Size, enemy.PhysicsComponent.Size, 10))
                return;

            _enemyRepository.Remove(enemy);
        }
    }
}