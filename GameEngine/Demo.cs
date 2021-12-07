using GameEngine.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine
{
    public class Demo : NightEngine
    {
        Shape2D player;

        string[,] Map =
        {
            {".",".",".",".",".",".","." },
            {".",".",".",".",".",".","." },
            {".",".",".",".",".",".","." },
            {".",".","g",".","g","g","." },
            {"g","g","g","g","g","g","g" },
            {".",".",".",".",".",".","." },
        };

        public Demo() : base(new Vector2(1920,1080), "NightEngine Demo")
        {

        }

        public override void OnLoad()
        {
            BackgroundColor = Color.Orange;
            player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "palyer");
        }

        public override void OnDraw()
        {
            
        }

        #region forTesting
        //int frames = 0;
        //float x = 1f;
        int time = 0;
        #endregion
        public override void OnUpdate()
        {
            //Log.Info($"Frame : {frames}");
            ////player.Position.X += x;
            ////player.Scale.X += x;
            //frames++;
            if (time == 400)
            {
                player.DestroySelf();
            }
            time++;
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
