using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Texture
    {
        public string Tag { get;set; }
        public Bitmap Image { get; set; }

        public Texture(string tag, Bitmap image)
        {
            Tag = tag;
            Image = image;
        }
    }
}
