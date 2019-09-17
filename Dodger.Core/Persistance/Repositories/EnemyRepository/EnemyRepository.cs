using System;
using System.Collections.Generic;
using System.Linq;
using Dodger.Core.Entities.Enemy;

namespace Dodger.Core.Persistance.Repositories.EnemyRepository
{
    public class EnemyRepository : IEnemyRepository
    {
        private readonly List<Enemy> _enemies = new List<Enemy>();

        public IEnumerable<Enemy> GetAll() => _enemies.ToList();

        public void Add(Enemy enemy)
        {
            _enemies.Add(enemy);
            
            Added?.Invoke(this, new AddedEventArgs(enemy));
        }

        public void Remove(Enemy enemy)
        {
            _enemies.Remove(enemy);
            
            Removed?.Invoke(this, new RemovedEventArgs(enemy));
        }

        public event EventHandler<RemovedEventArgs> Removed;
        public event EventHandler<AddedEventArgs> Added;
    }

    public class AddedEventArgs
    {
        public AddedEventArgs(Enemy enemy)
        {
            Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public Enemy Enemy { get; set; }
    }
}