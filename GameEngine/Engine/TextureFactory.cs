using System.Drawing;
using System.Windows.Forms;

namespace GameEngine.Engine
{
    internal class TextureFactory
    {
        private string _directory = Application.StartupPath;
        internal static Texture BuildTexture(string path, string tag)
        {
            Log.Info($"Loading texture {tag}");
            Image imageTmp = Image.FromFile($"{Application.StartupPath}{path}/{tag}.png");
            var bitmapTemp = new Bitmap(imageTmp);

            Texture texture = new Texture(tag, bitmapTemp);

            return texture;
        }
    }
}