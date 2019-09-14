using System;
using System.Collections.Generic;
using Dodger.Core.Entities.Enemy;

namespace Dodger.Core.Repositories.EnemyRepository
{
    public interface IEnemyRepository
    {
        IEnumerable<Enemy> GetAll();
        void Add(Enemy enemy);
        void Remove(Enemy enemy);
        event EventHandler<RemovedEventArgs> Removed;
    }
}