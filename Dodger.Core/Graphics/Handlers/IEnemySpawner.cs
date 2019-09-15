namespace Dodger.Core.Graphics.Handlers
{
    public interface IEnemySpawner
    {
        void SpawnEnemy(Persistance.Repositories.AddedEventArgs eventArgs);
    }
}