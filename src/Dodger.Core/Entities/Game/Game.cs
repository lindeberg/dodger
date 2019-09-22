using System;
using System.Linq;
using Dodger.Core.Entities.Game.Components;

namespace Dodger.Core.Entities.Game
{
    public class Game
    {
        private readonly GameComponents _components;
        private readonly GameGraphicsComponents _graphicsComponents;
        private bool _itsOn = true;

        public Game(GameComponents components, GameGraphicsComponents graphicsComponents)
        {
            _components = components ?? throw new ArgumentNullException(nameof(components));
            _graphicsComponents = graphicsComponents ?? throw new ArgumentNullException(nameof(graphicsComponents));
            ConfigureEventHandlers();
        }

        public void Update()
        {
            if (!_itsOn)
                return;

            HandleInput();
            UpdatePlayer();
            AddScore();
            UpdateEnemies();
            DisposeEnemies();
            CheckForCollisions();
            SpawnEnemy();
        }

        public void Render()
        {
            RenderPlayer();
            RenderEnemies();
            RenderHealth();
            RenderScore();
        }
        
        private void HandleInput()
        {
            _graphicsComponents.InputHandler.Update();
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

        private void RenderScore()
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
}