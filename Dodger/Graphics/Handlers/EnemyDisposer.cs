using System;
using System.Linq;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Graphics.Handlers;
using Dodger.Core.Repositories.EnemyRepository;
using Dodger.Graphics.Controls.Enemy;

namespace Dodger.Graphics.Handlers
{
    public class EnemyDisposer : IEnemyDisposer
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly MainForm _form;

        public EnemyDisposer(IEnemyRepository enemyRepository, MainForm form)
        {
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            _form = form ?? throw new ArgumentNullException(nameof(form));
            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            _enemyRepository.Removed += (sender, e) => DisposeEnemy(e.Enemy);
        }

        public void DisposeEnemy(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            
            var pictureBox = _form.Controls
                .OfType<EnemyPictureBox>()
                .SingleOrDefault(x => x.Tag.ToString() == enemy.Id.ToString());

            if (pictureBox == null)
                return;
            
            _form.Controls.Remove(pictureBox);
        }
    }
}