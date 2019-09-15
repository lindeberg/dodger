using System;
using Dodger.Core.Graphics.Handlers;
using Dodger.Core.Persistance.Repositories;
using Dodger.Core.Repositories.EnemyRepository;
using Dodger.Graphics.Controls.Enemy;

namespace Dodger.Graphics.Handlers
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly MainForm _form;

        public EnemySpawner(IEnemyRepository enemyRepository, MainForm form)
        {
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            _form = form ?? throw new ArgumentNullException(nameof(form));

            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            _enemyRepository.Added += (sender, e) => SpawnEnemy(e);
        }
        
        public void SpawnEnemy(AddedEventArgs eventArgs)
        {
            var enemy = eventArgs.Enemy;
            
            var pictureBox = new EnemyPictureBox(enemy.Id, $"enemy-{enemy.Id}", enemy.PhysicsComponent.Size,
                enemy.PhysicsComponent.Location,
                "missile.png");

            _form.Controls.Add(pictureBox);
        }
    }
}