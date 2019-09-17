using Dodger.Core.Entities.Player;

namespace Dodger.Core.Graphics.Renderers
{
    public interface IScoreRenderer
    {
        void Render(IPlayer player);
    }
}