using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Shape2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";

        public Shape2D(Vector2 position, Vector2 scale, string tag)
        {
            Log.Info($"Adding new shape : {tag}");
            Position = position;
            Scale = scale;
            Tag = tag;

            NightEngine.RegisterShape(this);
        }

        public void DestroySelf()
        {
            Log.Info($"{Tag} has been destroyed");
            NightEngine.UnRegisterShape(this);
        }
    }
}
