using Dodger.Core.Entities.Enemy;

namespace Dodger.Core.Handlers
{
    public interface IEnemyDisposer
    {
        void DisposeEnemy(Enemy enemy);
        void DisposeEnemies();
    }
}