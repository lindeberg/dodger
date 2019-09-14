using System.Windows.Forms;

namespace Dodger.Core.Entities.Components.GraphicsComponent
{
    public interface IGraphicsComponent 
    {
        PictureBox PictureBox { get; set; }
        void Update(IInteractingGameObject gameObject);
    }
}