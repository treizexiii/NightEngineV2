using GameEngine.Engine.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GameEngine.Engine
{
    public class Canvas : Form
    {
        public Canvas()
        {
            DoubleBuffered = true;
        }
    }

    public abstract class NightEngine
    {
        private Vector2 _screenSize = new Vector2(1920, 1080);
        private Canvas _window = null;
        private Thread _gameLoopThread = null;
        private string _title = "New Game";

        public Color BackgroundColor = Color.Black;
        //public Vector2 CameraPosition = new Vector2().Zero();
        public Camera Camera = new Camera(new Vector2());

        private static List<Texture> AllTextures = new List<Texture>();
        private static List<Sprite2D> AllSprites = new List<Sprite2D>();

        public NightEngine(Vector2 screenSize, string title)
        {
            Log.Info("Game is loading...");
            _screenSize = screenSize;
            _title = title;

            _window = new Canvas();
            _window.Size = new Size((int)_screenSize.X, (int)_screenSize.Y);
            _window.Text = _title;
            _window.Paint += Renderer;
            _window.KeyUp += WindowKeyUp;
            _window.KeyDown += WindowKeyDown;

            _gameLoopThread = new Thread(GameLoop);
            _gameLoopThread.Start();

            Application.Run(_window);
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);
            g.TranslateTransform(Camera.GetXPos(), Camera.GetYPos());

            foreach (Sprite2D sprite in AllSprites)
            {
                g.DrawImage(sprite.Texture, sprite.Position.X, sprite.Position.Y, sprite.Scale.X, sprite.Scale.Y);
            }
        }

        public static void RegisterSprite(Sprite2D sprite)
        {
            AllSprites.Add(sprite);
        }

        public static void UnRegisterSprite(Sprite2D sprite)
        {
            if (AllSprites.Count == 0)
            {
                throw new IndexOutOfRangeException("No more sprite");
            }
            AllSprites.Remove(sprite);
        }

        public static void RegisterTextures(string path, string tag)
        {
            if (AllTextures.Exists(c => c.Tag == tag))
            {
                throw new TextureLoadingException($"Texture {tag} already exists", tag);
            }
            Texture texture = TextureFactory.BuildTexture(path, tag);
            AllTextures.Add(texture);
        }

        public static List<Sprite2D> GetAllSprite()
        {
            return AllSprites;
        }

        public static Texture GetTexture(string tag)
        {
            return AllTextures.FirstOrDefault(t => t.Tag == tag);
        }

        // Main loop
        private void GameLoop()
        {
            int fps = 60;
            long nanoPerFrame = (long)(1000000000 / fps);
            long lastTime = NanoTime();

            OnLoad();

            while (_gameLoopThread.IsAlive)
            {
                long nowTime = NanoTime();
                if ((nowTime - lastTime) < nanoPerFrame)
                {
                    continue;
                }
                lastTime = nowTime;
                try
                {
                    OnDraw();
                    _window.BeginInvoke((MethodInvoker)delegate { _window.Refresh(); });
                    OnUpdate(AllSprites);
                    long elapsed = NanoTime() - lastTime;
                    long milliSleep = (nanoPerFrame - elapsed) / 1000000;
                    if (milliSleep > 0)
                    {
                        Thread.Sleep((int)milliSleep);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Exception : {ex.GetType()} | {ex.Message}");
                    _gameLoopThread.Abort();
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        private void WindowKeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        public abstract void OnLoad();
        public abstract void OnUpdate(List<Sprite2D> AllSprites);
        public abstract void OnDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);

        private static long NanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
    }
}
