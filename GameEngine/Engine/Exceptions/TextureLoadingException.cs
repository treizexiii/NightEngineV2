using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine.Exceptions
{
    internal class TextureLoadingException : Exception
    {
        public string TextureName { get; set; }

        public TextureLoadingException(string message, string textureName) : base(message)
        {
            TextureName = textureName;
        }
    }
}
