using System;
using System.Linq;
using System.Windows.Forms;
using Dodger.Controls;
using Dodger.Core.Repositories;
using Dodger.Core.ValueObjects;

namespace Dodger.Handlers
{
    public class EnemyDisposer
    {
        private readonly Timer _movementTimer;
        private readonly IEnemyRepository _enemyRepository;
        private readonly MainForm _mainForm;

        public EnemyDisposer(Timer movementTimer, IEnemyRepository enemyRepository, MainForm mainForm)
        {
            _movementTimer = movementTimer ?? throw new ArgumentNullException(nameof(movementTimer));
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            _mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            _movementTimer.Tick += (sender, e) => DisposeEnemies();
        }

        private void DisposeEnemies()
        {
            var pictureBoxes = _mainForm
                .Controls
                .OfType<EnemyPictureBox>()
                .ToList();

            var enumerable = _enemyRepository.GetAll();
            foreach (var enemy in enumerable)
            {
                if (enemy.Location.IsWithinDimensions(new Size(_mainForm.Size.Width, _mainForm.Size.Height),
                    enemy.Size)) 
                    continue;

                var pictureBox = pictureBoxes
                    .SingleOrDefault(x => x.Tag?.ToString() == enemy.Id.ToString());
                
                if(pictureBox == null)
                    return;
                
                _mainForm.Controls.Remove(pictureBox);
                pictureBox.Dispose();
                _enemyRepository.Remove(enemy);
            }
        }
    }
}