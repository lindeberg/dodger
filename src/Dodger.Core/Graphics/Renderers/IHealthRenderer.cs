using Dodger.Core.Entities.Player;

namespace Dodger.Core.Graphics.Renderers
{
    public interface IHealthRenderer
    {
        void Render(IPlayer player);
    }
}