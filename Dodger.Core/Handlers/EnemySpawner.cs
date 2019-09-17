using System;
using Dodger.Core.Entities.Components.PhysicsComponent;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Entities.World;
using Dodger.Core.Persistance.Repositories.EnemyRepository;
using MovementComponent = Dodger.Core.Entities.Enemy.Components.MovementComponent;
using Point = Dodger.Core.ValueObjects.Point;
using Random = Dodger.Core.Utilities.Random;

namespace Dodger.Core.Handlers
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly IWorld _world;

        public EnemySpawner(IEnemyRepository enemyRepository, IWorld world)
        {
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            _world = world ?? throw new ArgumentNullException(nameof(world));
        }

        public void SpawnEnemy()
        {
            if (!ShouldSpawn())
                return;

            var enemy = BuildEnemy();

            _enemyRepository.Add(enemy);
        }

        private Enemy BuildEnemy()
        {
            var physicsComponent = new PhysicsComponent(CreateRandomPoint(), CreateRandomSize());
            var movementComponenet = new MovementComponent(CreateRandomMovementSpeed(), physicsComponent);
            return new Enemy(movementComponenet, physicsComponent);
        }

        private int CreateRandomMovementSpeed()
        {
            return Random.Next(3, 6);
        }

        private static bool ShouldSpawn()
        {
            var value = Random.Next(0, 1000);
            return value > 910;
        }

        private Point CreateRandomPoint()
        {
            var x = Random.Next(0, _world.Size.Width);

            var point = new Point(x, 0);

            return point;
        }

        private static ValueObjects.Size CreateRandomSize()
        {
            var x = Random.Next(20, 50);
            var y = Random.Next(20, 50);

            return new ValueObjects.Size(x, y);
        }
    }
}