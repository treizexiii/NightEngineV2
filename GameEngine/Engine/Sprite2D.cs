using System.Drawing;
using System.Linq;

namespace GameEngine.Engine
{
    public class Sprite2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";
        public Bitmap Texture = null;

        public Sprite2D(Vector2 position, Vector2 scale, Texture texture)
        {

            Position = position;
            Scale = scale;
            Tag = texture.Tag;
            Texture = texture.Image;

            Log.Info($"Adding new Sprite : {Tag}");
            NightEngine.RegisterSprite(this);
        }

        public virtual void DestroySelf()
        {
            Log.Info($"{Tag} has been destroyed");
            NightEngine.UnRegisterSprite(this);
        }

        public bool IsColliding(string tag)
        {
            foreach (Sprite2D sprite in NightEngine.GetAllSprite().Where(s => s.Tag == tag))
            {
                if (Position.X < sprite.Position.X + sprite.Scale.X &&
                Position.X + Scale.X > sprite.Position.X &&
                Position.Y < sprite.Position.Y + sprite.Scale.Y &&
                Position.Y + Scale.Y > sprite.Position.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
