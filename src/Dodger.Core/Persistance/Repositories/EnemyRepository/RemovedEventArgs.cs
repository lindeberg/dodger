using System;
using Dodger.Core.Entities.Enemy;

namespace Dodger.Core.Persistance.Repositories.EnemyRepository
{
    public class RemovedEventArgs
    {
        public RemovedEventArgs(Enemy enemy)
        {
            Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public Enemy Enemy { get; }
    }
}