using System;
using Dodger.Core.Handlers;

namespace Dodger.Core.Entities.Game
{
    public class Game
    {
        private readonly IEnemySpawner _enemySpawner;
        private readonly IScoreHandler _scoreHandler;

        public Game(IEnemySpawner enemySpawner, IScoreHandler scoreHandler)
        {
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _scoreHandler = scoreHandler ?? throw new ArgumentNullException(nameof(scoreHandler));
        }

        public void Start()
        {
            _scoreHandler.StartCountingScore();
            _enemySpawner.StartSpawningEnemies();
        }
    }
}