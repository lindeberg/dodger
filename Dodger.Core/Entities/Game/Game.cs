using System;
using System.Linq;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.World;
using Dodger.Core.Graphics.Handlers;
using Dodger.Core.Graphics.Renderers;
using Dodger.Core.Repositories.EnemyRepository;
using IEnemyDisposer = Dodger.Core.Handlers.IEnemyDisposer;
using IEnemySpawner = Dodger.Core.Handlers.IEnemySpawner;
using IScoreHandler = Dodger.Core.Handlers.IScoreHandler;

namespace Dodger.Core.Entities.Game
{
    public class Game
    {
        private readonly Timer _timer;
        private readonly GameComponents _components;
        private readonly GameGraphicsComponents _graphicsComponents;
        private bool _itsOn;

        public Game(Timer timer, GameComponents components, GameGraphicsComponents graphicsComponents)
        {
            _timer = timer ?? throw new ArgumentNullException(nameof(timer));
            _components = components ?? throw new ArgumentNullException(nameof(components));
            _graphicsComponents = graphicsComponents ?? throw new ArgumentNullException(nameof(graphicsComponents));
            ConfigureEventHandlers();
        }

        public void Start()
        {
            _itsOn = true;
            _timer.Tick += (sender, e) => Iteration();
        }

        private void Iteration()
        {
            if (!_itsOn)
                return;

            UpdatePlayer();
            AddScore();
            UpdateEnemies();
            DisposeEnemies();
            CheckForCollisions();
            SpawnEnemy();
            Render();
        }

        private void Render()
        {
            RenderHealth();
            RenderPoints();
            RenderPlayer();
            RenderEnemies();
        }

        private void RenderPlayer()
        {
            _graphicsComponents.PlayerRenderer.Render(_components.Player);
        }

        private void RenderEnemies()
        {
            foreach (var enemy in _components.EnemyRepository.GetAll().ToList())
            {
                _graphicsComponents.EnemyRenderer.Render(enemy);
            }
        }

        private void RenderPoints()
        {
            _graphicsComponents.ScoreRenderer.Render(_components.Player);
        }

        private void RenderHealth()
        {
            _graphicsComponents.HealthRenderer.Render(_components.Player);
        }

        private void CheckForCollisions()
        {
            var enemies = _components.EnemyRepository
                .GetAll()
                .Where(enemy => _components.Player.PhysicsComponent.IsCollidingWith(enemy.PhysicsComponent))
                .ToList();

            foreach (var enemy in enemies)
            {
                _components.Player.Health.LosePoint();
                _components.EnemyRepository.Remove(enemy);
            }
        }

        private void AddScore()
        {
            _components.ScoreHandler.AddPoint();
        }

        private void DisposeEnemies()
        {
            _components.EnemyDisposer.DisposeEnemies();
        }

        private void SpawnEnemy()
        {
            _components.EnemySpawner.SpawnEnemy();
        }

        private void UpdatePlayer()
        {
            _components.Player.Update(_components.World);
        }

        private void UpdateEnemies()
        {
            foreach (var enemy in _components.EnemyRepository.GetAll())
            {
                enemy.Update(_components.World);
            }
        }

        private void ConfigureEventHandlers()
        {
            _components.Player.Health.Died += (sender, e) => OnPlayerDied();
        }

        private void OnPlayerDied()
        {
            _itsOn = false;
        }
    }


    public class GameComponents
    {
        public GameComponents(IEnemySpawner enemySpawner, IEnemyDisposer enemyDisposer, IScoreHandler scoreHandler,
            IWorld world, IPlayer player, IEnemyRepository enemyRepository)
        {
            EnemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            EnemyDisposer = enemyDisposer ?? throw new ArgumentNullException(nameof(enemyDisposer));
            ScoreHandler = scoreHandler ?? throw new ArgumentNullException(nameof(scoreHandler));
            World = world ?? throw new ArgumentNullException(nameof(world));
            Player = player ?? throw new ArgumentNullException(nameof(player));
            EnemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
        }

        public IEnemySpawner EnemySpawner { get; set; }
        public IEnemyDisposer EnemyDisposer { get; set; }
        public IScoreHandler ScoreHandler { get; set; }
        public IWorld World { get; set; }
        public IPlayer Player { get; set; }
        public IEnemyRepository EnemyRepository { get; set; }
    }

    public class GameGraphicsComponents
    {
        public GameGraphicsComponents(IScoreRenderer scoreRenderer, IEnemyRenderer enemyRenderer,
            IPlayerRenderer playerRenderer,
            IInputHandler inputHandler, IHealthRenderer healthRenderer)
        {
            ScoreRenderer = scoreRenderer ?? throw new ArgumentNullException(nameof(scoreRenderer));
            EnemyRenderer = enemyRenderer ?? throw new ArgumentNullException(nameof(enemyRenderer));
            PlayerRenderer = playerRenderer ?? throw new ArgumentNullException(nameof(playerRenderer));
            InputHandler = inputHandler ?? throw new ArgumentNullException(nameof(inputHandler));
            HealthRenderer = healthRenderer ?? throw new ArgumentNullException(nameof(healthRenderer));
        }

        public IScoreRenderer ScoreRenderer { get; set; }
        public IEnemyRenderer EnemyRenderer { get; set; }
        public IPlayerRenderer PlayerRenderer { get; set; }
        public IInputHandler InputHandler { get; set; }
        public IHealthRenderer HealthRenderer { get; set; }
    }
}