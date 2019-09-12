using System;
using Dodger.Core.Handlers;

namespace Dodger.Core.Entities
{
    public class Game
    {
        private readonly IEnemySpawner _enemySpawner;
        private readonly IScoreHandler _scoreHandler;
        private readonly IPlayerMover _playerMover;

        public Game(IEnemySpawner enemySpawner, IScoreHandler scoreHandler, IPlayerMover playerMover)
        {
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _scoreHandler = scoreHandler ?? throw new ArgumentNullException(nameof(scoreHandler));
            _playerMover = playerMover ?? throw new ArgumentNullException(nameof(playerMover));
        }

        public void Start()
        {
            _scoreHandler.StartCountingScore();
           _enemySpawner.StartSpawningEnemies();
        }
    }
}