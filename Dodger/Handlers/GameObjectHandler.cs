using System;
using System.Windows.Forms;
using Dodger.Core.Entities.Player;
using Dodger.Core.Entities.World;
using Dodger.Core.Repositories.EnemyRepository;

namespace Dodger.Handlers
{
    public class GameObjectHandler
    {
        private readonly Timer _movementTimer;
        private readonly IEnemyRepository _enemyRepository;
        private readonly IWorld _world;
        private readonly Player _player;

        public GameObjectHandler(Timer movementTimer, IEnemyRepository enemyRepository, IWorld world, Player player)
        {
            _movementTimer = movementTimer ?? throw new ArgumentNullException(nameof(movementTimer));
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            _world = world ?? throw new ArgumentNullException(nameof(world));
            _player = player ?? throw new ArgumentNullException(nameof(player));

            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            _movementTimer.Tick += (sender, e) => MovePlayer();
            _movementTimer.Tick += (sender, e) => MoveEnemies();
        }
        
        private void MovePlayer()
        {
            _player.Update(_world);
        }
        
        private void MoveEnemies()
        {
            foreach (var enemy in _enemyRepository.GetAll())
            {
                enemy.Update(_world);
            }
        }
        
    }
}