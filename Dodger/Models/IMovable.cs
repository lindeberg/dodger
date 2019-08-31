namespace Dodger.Models
{
    public interface IMovable
    {
        void Move(Direction direction);
        Point Location { get; }
        int MovementSpeed { get; set; }

    }
}