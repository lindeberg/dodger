using System;
using System.Collections.Generic;
using Dodger.Core.Entities.Enemy;
using Dodger.Core.Persistance.Repositories;

namespace Dodger.Core.Repositories.EnemyRepository
{
    public interface IEnemyRepository
    {
        IEnumerable<Enemy> GetAll();
        void Add(Enemy enemy);
        void Remove(Enemy enemy);
        event EventHandler<RemovedEventArgs> Removed;
        event EventHandler<AddedEventArgs> Added;
    }
}