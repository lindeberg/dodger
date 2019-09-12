using Dodger.Core.ValueObjects;

namespace Dodger.Core.Entities
{
    public interface IInteractingObject : IMovable
    {
        string ImagePath { get; }
        Size Size { get; set; }
    }
}