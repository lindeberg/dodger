using System;
using System.Collections.Generic;
using System.Linq;
using Dodger.Core.Entities;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Repositories.EnemyRepository;

namespace Dodger.Persistance.Repositories
{
    public class EnemyRepository : IEnemyRepository
    {
        private readonly List<Enemy> _enemies = new List<Enemy>();

        public IEnumerable<Enemy> GetAll() => _enemies.ToList();

        public void Add(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void Remove(Enemy enemy)
        {
            _enemies.Remove(enemy);
            
            Removed?.Invoke(this, new RemovedEventArgs(enemy));
        }

        public event EventHandler<RemovedEventArgs> Removed;
    }
}