using System;
using System.Drawing;
using System.Linq;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Graphics.Handlers;
using Dodger.Graphics.Controls.Enemy;

namespace Dodger.Graphics.Handlers
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
            
            SetLocation(enemy);
        }

        private void SetLocation(Enemy enemy)
        {
            if (enemy == null) throw new ArgumentNullException(nameof(enemy));
            
            var pictureBox = _form
                .Controls
                .OfType<EnemyPictureBox>()
                .SingleOrDefault(x => x.Tag.ToString() == enemy.Id.ToString());
            
            if(pictureBox == null)
                return;
            
            pictureBox.Location = new Point(enemy.PhysicsComponent.Location.X, enemy.PhysicsComponent.Location.Y);
        }
    }
}