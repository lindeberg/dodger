using System;
using System.Linq;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Entities.Enemy.Controls;
using Dodger.Core.Repositories.EnemyRepository;

namespace Dodger.Handlers
{
    public class EnemyGraphicsDisposer
    {
        private readonly IEnemyRepository _repository;
        private readonly MainForm _form;

        public EnemyGraphicsDisposer(IEnemyRepository repository, MainForm form)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _form = form ?? throw new ArgumentNullException(nameof(form));
            ConfigureEventHandlers();
        }

        private void ConfigureEventHandlers()
        {
            _repository.Removed += (sender, e) => RemovePictureBox(e.Enemy);
        }

        private void RemovePictureBox(Enemy enemy)
        {
            var pictureBox = _form.Controls
                .OfType<EnemyPictureBox>()
                .SingleOrDefault(x => x.Tag.ToString() == enemy.Id.ToString());

            if (pictureBox == null)
                return;
            
            _form.Controls.Remove(pictureBox);
        }
    }
}