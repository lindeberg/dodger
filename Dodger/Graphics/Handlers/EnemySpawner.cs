using System;
using Dodger.Graphics.Controls.Enemy;

namespace Dodger.Graphics.Handlers
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly Core.Handlers.IEnemySpawner _enemySpawner;
        private readonly MainForm _form;

        public EnemySpawner(Core.Handlers.IEnemySpawner enemySpawner, MainForm form)
        {
            _enemySpawner = enemySpawner ?? throw new ArgumentNullException(nameof(enemySpawner));
            _form = form ?? throw new ArgumentNullException(nameof(form));

            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            _enemySpawner.SpawnedEnemy += (sender, e) => SpawnEnemy(e);
        }
        
        public void SpawnEnemy(Core.Handlers.SpawnedEnemyEventArgs eventArgs)
        {
            var enemy = eventArgs.Enemy;
            
            var pictureBox = new EnemyPictureBox(enemy.Id, $"enemy-{enemy.Id}", enemy.PhysicsComponent.Size,
                enemy.PhysicsComponent.Location,
                "missile.png");

            enemy.GraphicsComponent.PictureBox = pictureBox;
            
            _form.Controls.Add(pictureBox);
        }
    }
}