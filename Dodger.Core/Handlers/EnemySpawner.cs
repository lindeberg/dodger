using System;
using Dodger.Core.Entities.Components.PhysicsComponent;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Entities.World;
using Dodger.Core.Repositories.EnemyRepository;
using MovementComponent = Dodger.Core.Entities.Enemy.Components.MovementComponent;
using Point = Dodger.Core.ValueObjects.Point;

namespace Dodger.Core.Handlers
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly IWorld _world;
        public event EventHandler<SpawnedEnemyEventArgs> SpawnedEnemy;

        public EnemySpawner(IEnemyRepository enemyRepository, IWorld world)
        {
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            _world = world ?? throw new ArgumentNullException(nameof(world));
        }

        public void SpawnEnemy()
        {
            if (!ShouldSpawn())
                return;

            var physicsComponent = new PhysicsComponent(CreateRandomPoint(), CreateRandomSize());
            var movementComponenet = new MovementComponent(5, physicsComponent);
            var enemy = new Enemy(movementComponenet, physicsComponent);

            SpawnedEnemy?.Invoke(this, new SpawnedEnemyEventArgs(enemy));

            _enemyRepository.Add(enemy);
        }

        private static bool ShouldSpawn()
        {
            var random = new Random();
            var value = random.Next(0, 1000);
            return value > 800;
        }

        private Point CreateRandomPoint()
        {
            var random = new Random();
            var x = random.Next(0, _world.Size.Width);

            var point = new Point(x, 0);

            return point;
        }

        private static ValueObjects.Size CreateRandomSize()
        {
            var random = new Random();
            var x = random.Next(0, 100);
            var y = random.Next(0, 100);

            return new ValueObjects.Size(x, y);
        }
    }

    public class SpawnedEnemyEventArgs
    {
        public SpawnedEnemyEventArgs(Enemy enemy)
        {
            Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public Enemy Enemy { get; }
    }
}