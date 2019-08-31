using System;
using Dodger.Handlers;

namespace Dodger.Models
{
    public class Game
    {
        private readonly IEnemySpawner _enemySpawner;
        private readonly IScoreHandler _scoreHandler;
        private readonly IPlayerHandler _playerHandler;

        public Game(IEnemySpawner enemySpawner, IScoreHandler scoreHandler, IPlayerHandler playerHandler)
        {
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _scoreHandler = scoreHandler ?? throw new ArgumentNullException(nameof(scoreHandler));
            _playerHandler = playerHandler ?? throw new ArgumentNullException(nameof(playerHandler));
        }

        public void Start()
        {
            _scoreHandler.StartCountingScore();
            _enemySpawner.StartSpawningEnemies();
        }
    }
}