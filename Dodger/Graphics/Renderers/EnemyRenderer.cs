using System;
using System.Drawing;
using System.Linq;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Graphics.Renderers;
using Dodger.Graphics.Controls.Enemy;

namespace Dodger.Graphics.Renderers
{
    public class EnemyRenderer : IEnemyRenderer
    {
        private readonly MainForm _form;

        public EnemyRenderer(MainForm form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
        }
        
        public void Render(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            
            var pictureBox = _form
                .Controls
                .OfType<EnemyPictureBox>()
                .Single(x => x.Tag.ToString() == enemy.Id.ToString());

            SetLocation(enemy, pictureBox);
        }

        private void SetLocation(Enemy enemy, EnemyPictureBox pictureBox)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            if (pictureBox == null) throw new ArgumentNullException(nameof(pictureBox));

            pictureBox.Location = new Point(enemy.PhysicsComponent.Location.X, enemy.PhysicsComponent.Location.Y);
        }
    }
}