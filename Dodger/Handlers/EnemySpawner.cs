using System;
using System.Windows.Forms;
using Dodger.Controls;
using Dodger.Core.Entities;
using Dodger.Core.Handlers;
using Dodger.Core.Repositories;
using PictureBox = System.Windows.Forms.PictureBox;
using Point = Dodger.Core.ValueObjects.Point;

namespace Dodger.Handlers
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly Timer _enemySpawnTimer;
        private readonly MainForm _form;
        private readonly Timer _movementTimer;
        private readonly IEnemyRepository _enemyRepository;

        public EnemySpawner(Timer enemySpawnTimer, MainForm form, Timer movementTimer, IEnemyRepository enemyRepository)
        {
            _enemySpawnTimer = enemySpawnTimer ?? throw new ArgumentNullException(nameof(enemySpawnTimer));
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _movementTimer = movementTimer ?? throw new ArgumentNullException(nameof(movementTimer));
            _enemyRepository = enemyRepository;
        }

        public void StartSpawningEnemies()
        {
            _enemySpawnTimer.Tick += (sender, e) => SpawnEnemy();
            _movementTimer.Tick += (sender, e) => MoveEnemies();
        }

        private void MoveEnemies()
        {
            foreach (var enemy in _enemyRepository.GetAll())
            {
                MoveEnemy(enemy);
            }
        }

        private void SpawnEnemy()
        {
            var enemy = new Enemy(CreateRandomPoint())
            {
                Size = CreateRandomSize()
            };

            var pictureBox = new EnemyPictureBox(enemy.Id, $"enemy-{enemy.Id}", enemy.Size, enemy.Location, enemy.ImagePath);
            _form.Controls.Add(pictureBox);
            
            enemy.Moved += (sender, e) => MovePictureBox(enemy, pictureBox);

            _enemyRepository.Add(enemy);
        }

        private Point CreateRandomPoint()
        {
            var random = new Random();
            var x = random.Next(0, _form.Width);

            var point = new Point(x, 0);

            return point;
        }

        private static Core.ValueObjects.Size CreateRandomSize()
        {
            var random = new Random();
            var x = random.Next(0, 100);
            var y = random.Next(0, 100);

            return new Core.ValueObjects.Size(x, y);
        }


        private void MovePictureBox(Enemy enemy, PictureBox pictureBox)
        {
            pictureBox.Location = new System.Drawing.Point(enemy.Location.X, enemy.Location.Y);
        }

        private void MoveEnemy(Enemy enemy)
        {
            var space = new Core.ValueObjects.Size(_form.Size.Width, _form.Size.Height);
            enemy.Move(space);
        }
    }
}