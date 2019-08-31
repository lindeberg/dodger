namespace Dodger.Models
{
    public interface IInteractingObject : IMovable
    {
        string ImagePath { get; }
        Size Size { get; }
    }
}