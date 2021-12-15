namespace GameEngine.Engine
{
    public class Camera
    {
        Vector2 Position;

        public Camera(Vector2 position)
        {
            Position = new Vector2();
            Position.X = position.X;
            Position.Y = position.Y;
        }

        public void MoveCamera(Vector2 coordinates)
        {
            Position.X = coordinates.X;
            Position.Y = coordinates.Y;
        }

        public float GetXPos()
        {
            return Position.X;
        }

        public float GetYPos()
        {
            return Position.Y;
        }
    }
}
