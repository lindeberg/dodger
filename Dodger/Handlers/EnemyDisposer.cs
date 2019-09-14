using System;
using Dodger.Controls;
using Dodger.Core.Entities;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Entities.World;
using Dodger.Core.Handlers;
using Dodger.Core.Repositories.EnemyRepository;
using Dodger.Core.ValueObjects;

namespace Dodger.Handlers
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

        public void DisposeEnemy(Enemy enemy)
        {
            if (enemy.PhysicsComponent.Location.IsWithinDimensions(_world.Size, enemy.PhysicsComponent.Size)) 
                return;

            _enemyRepository.Remove(enemy);
        }
    }
}