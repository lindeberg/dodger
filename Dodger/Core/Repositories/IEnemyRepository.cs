using System.Collections.Generic;
using Dodger.Core.Entities;

namespace Dodger.Core.Repositories
{
    public interface IEnemyRepository
    {
        IEnumerable<Enemy> GetAll();
        void Add(Enemy enemy);
        void Remove(Enemy enemy);
    }
}