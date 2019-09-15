using System;
using System.Windows.Forms;

namespace Dodger.Core.Entities.Components.GraphicsComponent
{
    public abstract class GraphicsComponent : IGraphicsComponent
    {
        public GraphicsComponent()
        {
        }
        public PictureBox PictureBox { get; set; }
        
        public virtual void Update(IInteractingGameObject obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            
            Move(obj);
        }
        
        private void Move(IInteractingGameObject obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            
            if(PictureBox == null)
                return;
            
            PictureBox.Location = new System.Drawing.Point(obj.Location.X, obj.Location.Y);
        }
    }
}