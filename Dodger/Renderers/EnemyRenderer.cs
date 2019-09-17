using System;
using System.Drawing;
using System.Linq;
using Dodger.Controls.Enemy;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Graphics.Renderers;
using Dodger.Core.Repositories.EnemyRepository;

namespace Dodger.Renderers
{
    public class EnemyRenderer : IEnemyRenderer
    {
        private readonly MainForm _form;
        private readonly IEnemyRepository _enemyRepository;

        public EnemyRenderer(MainForm form, IEnemyRepository enemyRepository)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
            _enemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            _enemyRepository.Removed += (sender, e) => Remove(e.Enemy);
            _enemyRepository.Added += (sender, e) => Render(e.Enemy);
        }

        public void Render(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));

            var pictureBox = GetPictureBox(enemy);

            if (pictureBox == null)
            {
                AddPictureBox(enemy);
            }
            else
            {
                SetLocation(enemy, pictureBox);
            }
        }
        
        public void Remove(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));

            var pictureBox = _form.Controls
                .OfType<EnemyPictureBox>()
                .SingleOrDefault(x => x.Tag.ToString() == enemy.Id.ToString());

            if (pictureBox == null)
                return;

            _form.Controls.Remove(pictureBox);
        }
        
        private EnemyPictureBox GetPictureBox(Enemy enemy)
        {
            return _form
                .Controls
                .OfType<EnemyPictureBox>()
                .SingleOrDefault(x => x.Tag.ToString() == enemy.Id.ToString());
        }

        private void AddPictureBox(Enemy enemy)
        {
            var pictureBox = new EnemyPictureBox(enemy.Id, $"enemy-{enemy.Id}", enemy.PhysicsComponent.Size,
                enemy.PhysicsComponent.Location,
                "missile.png");

            _form.Controls.Add(pictureBox);
        }

        private void SetLocation(Enemy enemy, EnemyPictureBox pictureBox)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            if (pictureBox == null) throw new ArgumentNullException(nameof(pictureBox));

            pictureBox.Location = new Point(enemy.PhysicsComponent.Location.X, enemy.PhysicsComponent.Location.Y);
        }
    }
}