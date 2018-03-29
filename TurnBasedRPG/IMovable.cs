namespace TurnBasedRPG
{
    public interface IMovable
    {
        Vector2 Position { get; }
        void Move(Vector2 offset);
    }
}