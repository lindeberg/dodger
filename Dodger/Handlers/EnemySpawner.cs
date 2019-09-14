using System;
using System.Windows.Forms;
using Dodger.Core.Entities.Components.PhysicsComponent;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Entities.Enemy.Controls;
using Dodger.Core.Entities.World;
using Dodger.Core.Handlers;
using Dodger.Core.Repositories.EnemyRepository;
using GraphicsComponent = Dodger.Core.Entities.Enemy.Components.GraphicsComponent;
using MovementComponent = Dodger.Core.Entities.Enemy.Components.MovementComponent;
using Point = Dodger.Core.ValueObjects.Point;

namespace Dodger.Handlers
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly Timer _enemySpawnTimer;
        private readonly IEnemyRepository _enemyRepository;
        private readonly IWorld _world;
        private readonly MainForm _form;

        public event EventHandler<SpawnedEnemyEventArgs> SpawnedEnemy;

        public EnemySpawner(Timer enemySpawnTimer, IEnemyRepository enemyRepository, IWorld world, MainForm form)
        {
            _enemySpawnTimer = enemySpawnTimer ?? throw new ArgumentNullException(nameof(enemySpawnTimer));
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            _world = world ?? throw new ArgumentNullException(nameof(world));
            _form = form ?? throw new ArgumentNullException(nameof(form));
        }

        public void StartSpawningEnemies()
        {
            _enemySpawnTimer.Tick += (sender, e) => SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            var physicsComponent = new PhysicsComponent(CreateRandomPoint(), CreateRandomSize());
            var movementComponenet = new MovementComponent(5, physicsComponent);
            var graphicsComponent = new GraphicsComponent();
            var enemy = new Enemy(movementComponenet, physicsComponent, graphicsComponent);
            
            var pictureBox = new EnemyPictureBox(enemy.Id, $"enemy-{enemy.Id}", enemy.PhysicsComponent.Size, enemy.PhysicsComponent.Location,
                "missile.png");
            
            _form.Controls.Add(pictureBox);

            SpawnedEnemy?.Invoke(this, new SpawnedEnemyEventArgs(enemy));

            _enemyRepository.Add(enemy);
        }

        private Point CreateRandomPoint()
        {
            var random = new Random();
            var x = random.Next(0, _world.Size.Width);

            var point = new Point(x, 0);

            return point;
        }

        private static Core.ValueObjects.Size CreateRandomSize()
        {
            var random = new Random();
            var x = random.Next(0, 100);
            var y = random.Next(0, 100);

            return new Core.ValueObjects.Size(x, y);
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