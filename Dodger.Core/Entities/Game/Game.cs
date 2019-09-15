using System;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.World;
using Dodger.Core.Graphics.Handlers;
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

        public Game(Timer timer, GameComponents components, GameGraphicsComponents graphicsComponents)
        {
            _timer = timer ?? throw new ArgumentNullException(nameof(timer));
            _components = components ?? throw new ArgumentNullException(nameof(components));
            _graphicsComponents = graphicsComponents ?? throw new ArgumentNullException(nameof(graphicsComponents));
        }

        public void Start()
        {
            _timer.Tick += (sender, e) => Update();
        }

        private void Update()
        {
            UpdatePlayer();
            UpdateEnemies();
            SpawnEnemy();
            DisposeEnemies();
            AddScore();
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
            _graphicsComponents.PlayerRenderer.Render(_components.Player);
        }

        private void UpdateEnemies()
        {
            foreach (var enemy in _components.EnemyRepository.GetAll())
            {
                enemy.Update(_components.World);
                _graphicsComponents.EnemyRenderer.Render(enemy);
            }
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
        public GameGraphicsComponents(Graphics.Handlers.IEnemySpawner enemySpawner,
            Graphics.Handlers.IEnemyDisposer enemyDisposer,
            Graphics.Handlers.IScoreHandler scoreHandler, IEnemyRenderer enemyRenderer, IPlayerRenderer playerRenderer,
            IInputHandler inputHandler)
        {
            EnemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            EnemyDisposer = enemyDisposer ?? throw new ArgumentNullException(nameof(enemyDisposer));
            ScoreHandler = scoreHandler ?? throw new ArgumentNullException(nameof(scoreHandler));
            EnemyRenderer = enemyRenderer ?? throw new ArgumentNullException(nameof(enemyRenderer));
            PlayerRenderer = playerRenderer ?? throw new ArgumentNullException(nameof(playerRenderer));
            InputHandler = inputHandler ?? throw new ArgumentNullException(nameof(inputHandler));
        }

        public Graphics.Handlers.IEnemySpawner EnemySpawner { get; set; }
        public Graphics.Handlers.IEnemyDisposer EnemyDisposer { get; set; }
        public Graphics.Handlers.IScoreHandler ScoreHandler { get; set; }
        public IEnemyRenderer EnemyRenderer { get; set; }
        public IPlayerRenderer PlayerRenderer { get; set; }
        public IInputHandler InputHandler { get; set; }
    }
}