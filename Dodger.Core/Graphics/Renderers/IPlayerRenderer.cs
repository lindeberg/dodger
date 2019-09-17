using Dodger.Core.Entities.Player;

namespace Dodger.Core.Graphics.Renderers
{
    public interface IPlayerRenderer
    {
        void Render(IPlayer player);
    }
}