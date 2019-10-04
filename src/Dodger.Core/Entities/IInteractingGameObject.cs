using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities
{
    public interface IInteractingGameObject 
    {
        Size Size { get; set; }
        Point Location { get; set; }
    }
}