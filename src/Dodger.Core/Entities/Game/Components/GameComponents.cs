using System;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.World;
using Dodger.Core.Handlers;
using Dodger.Core.Persistance.Repositories.EnemyRepository;

namespace Dodger.Core.Entities.Game.Components
{
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
}