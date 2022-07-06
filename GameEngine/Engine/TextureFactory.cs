using System.Drawing;
using System.Windows.Forms;

namespace GameEngine.Engine
{
    internal static class TextureFactory
    {
        private static readonly string Directory = Application.StartupPath;
        internal static Texture BuildTexture(string path, string tag)
        {
            Log.Info($"Loading texture {tag}");
            Image imageTmp = Image.FromFile($"{Directory}{path}{tag}.png");
            var bitmapTemp = new Bitmap(imageTmp);

            Texture texture = new Texture(tag, bitmapTemp);

            return texture;
        }
    }
}