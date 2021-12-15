using GameEngine.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngine
{
    public class Demo : NightEngine
    {
        private string AssetPath = "\\Assets\\";

        bool _up = false;
        bool _down = false;
        bool _left = false;
        bool _right = false;

        Sprite2D player;
        Vector2 lasPos = new Vector2();

        string[,] Map =
        {
            {"g","g","g","g","g","g","g","g","g","g","g","g","g","g","g"},
            {"g",".",".",".",".",".",".",".","g",".",".",".","g",".","g"},
            {"g",".",".",".",".",".",".",".","g",".","g",".","g",".","g"},
            {"g","g","g",".",".","g",".",".","g",".","g",".","g",".","g"},
            {"g",".",".",".",".","g",".",".","g",".","g",".","g",".","g"},
            {"g",".",".",".","g","g",".",".",".",".","g",".","g",".","g"},
            {"g",".",".","g","g","g",".",".",".",".","g",".","g",".","g"},
            {"g","g","g","g","g","g","g","g","g",".","g",".","g",".","g"},
            {"g","g","g","g","g","g","g","g",".",".","g",".",".",".","g"},
            {"g","g","g","g","g","g","g","g","g","g","g","g","g","g","g"},
        };

        public Demo() : base(new Vector2(1366, 768), "NightEngine Demo")
        {
        }

        public override void OnLoad()
        {
            Log.Info("Loading...");
            Console.WriteLine($"{AssetPath}");

            BackgroundColor = Color.Orange;

            RegisterTextures(AssetPath, "ground");
            RegisterTextures(AssetPath, "player");

            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 70, j * 70), new Vector2(70, 70), GetTexture("ground"));
                    }
                }
            }
            player = new Sprite2D(new Vector2(70, 70), new Vector2(70, 70), GetTexture("player"));
        }

        public override void OnDraw()
        {
        }

        public override void OnUpdate(List<Sprite2D> AllSprites)
        {
            Camera.MoveCamera(player.Position);

            if (_up) player.Position.Y -= 10f;
            if (_down) player.Position.Y += 10f;
            if (_right) player.Position.X += 10f;
            if (_left) player.Position.X -= 10f;

            if (player.IsColliding("ground"))
            {
                player.Position.X = lasPos.X;
                player.Position.Y = lasPos.Y;
            }
            else
            {
                lasPos.X = player.Position.X;
                lasPos.Y = player.Position.Y;
            }
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { _up = true; }
            if (e.KeyCode == Keys.Down) { _down = true; }
            if (e.KeyCode == Keys.Left) { _left = true; }
            if (e.KeyCode == Keys.Right) { _right = true; }
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { _up = false; }
            if (e.KeyCode == Keys.Down) { _down = false; }
            if (e.KeyCode == Keys.Right) { _right = false; }
            if (e.KeyCode == Keys.Left) { _left = false; }
        }
    }
}
