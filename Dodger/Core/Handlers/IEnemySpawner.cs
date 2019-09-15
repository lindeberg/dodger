using System;

namespace Dodger.Core.Handlers
{
    public interface IEnemySpawner
    {
        event EventHandler<SpawnedEnemyEventArgs> SpawnedEnemy;
        void SpawnEnemy();
    }
}