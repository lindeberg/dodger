using Dodger.Core.Entities.Enemy;

namespace Dodger.Core.Graphics.Renderers
{
    public interface IEnemyRenderer
    {
        void Render(Enemy enemy);
        void Remove(Enemy enemy);
    }
}