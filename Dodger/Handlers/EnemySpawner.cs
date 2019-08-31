using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Dodger.Annotations;
using Dodger.Entities;
using Dodger.Models;
using Point = Dodger.Models.Point;
using Size = System.Drawing.Size;

namespace Dodger.Handlers
{
    public class EnemySpawner : IEnemySpawner
    {
        private readonly Timer _enemySpawnTimer;
        private readonly MainForm _form;
        private readonly Player _player;
        private int _enemyCount;

        public EnemySpawner(Timer enemySpawnTimer, MainForm form, Player player)
        {
            _enemySpawnTimer = enemySpawnTimer ?? throw new ArgumentNullException(nameof(enemySpawnTimer));
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public void StartSpawningEnemies()
        {
            _enemySpawnTimer.Tick += SpawnEnemy;
        }

        private void SpawnEnemy(object sender, EventArgs e)
        {
            var location = CreateRandomPoint();
            var enemy = new Enemy(location);

            var pictureBox = CreateAndSetEnemyPicture(enemy);

            CreateAndSetEnemyMovementTimer(enemy, pictureBox);

            _enemyCount++;

            Point CreateRandomPoint()
            {
                var random = new Random();
                var x = random.Next(0, _form.Width);
                var y = random.Next(0, _form.Height);
                
                var point = new Point(x, y);

                while (LocationIsTooCloseToPlayer(point))
                {
                    x = random.Next(0, _form.Width);
                    y = random.Next(0, _form.Height);
                
                    point = new Point(x, y);
                }
                
                return point;
            }
        }

        private bool LocationIsTooCloseToPlayer(Point location)
        {
            //TODO: Implement
            return false;
        }

        private void CreateAndSetEnemyMovementTimer(Enemy enemy, PictureBox pictureBox)
        {
            var timer = new Timer
            {
                Enabled = true,
                Interval = new Random().Next(enemy.SpawnTimeInterval.Min, enemy.SpawnTimeInterval.Max),
            };
            
            timer.Tick += (sender, e) => MoveEnemy(enemy);
            enemy.Moved += (sender, e) => MovePictureBox(enemy, pictureBox);
        }
        
        private void MovePictureBox(Enemy enemy, PictureBox pictureBox)
        {
            var location = enemy.Location;
            pictureBox.Location = new System.Drawing.Point(location.X, location.Y);
        }

        private void MoveEnemy(Enemy enemy)
        {
            var directions = Enum.GetValues(typeof(Direction));

            var random = new Random();

            var direction = (Direction) directions.GetValue(random.Next(directions.Length));
            
            enemy.Move(direction);
        }

        private PictureBox CreateAndSetEnemyPicture(Enemy enemy)
        {
            var pictureBox = new PictureBox
            {
                Name = "enemy" + _enemyCount,
                Size = new Size(enemy.Size.Width, enemy.Size.Height),
                Location = new System.Drawing.Point(enemy.Location.X, enemy.Location.Y),
                Image = GetImage(),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            
            _form.Controls.Add(pictureBox);

            return pictureBox;

            Image GetImage()
            {
                var ImagesDirectoryPath = 
                    Path.Combine(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        @"Assets\Images"
                    );

                var imagePath = Path.Combine(ImagesDirectoryPath, enemy.ImagePath);

                return Image.FromFile(imagePath);
            }
        }
    }
}