using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        public Vector2 CameraPosition = new Vector2().Zero();
        
        private static List<Shape2D> AllShapes = new List<Shape2D>();

        public NightEngine(Vector2 screenSize, string title)
        {
            Log.Info("Game is loading...");
            _screenSize = screenSize;
            _title = title;

            _window = new Canvas();
            _window.Size = new Size((int)_screenSize.X, (int)_screenSize.Y);
            _window.Text = _title;
            _window.Paint += Renderer;

            _gameLoopThread = new Thread(GameLoop);
            _gameLoopThread.Start();

            Application.Run(_window);
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);

            g.TranslateTransform(CameraPosition.X, CameraPosition.Y);

            foreach (Shape2D shape in AllShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }
        }

        public static void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
        }

        public static void UnRegisterShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
        }

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
                    OnUpdate();
                    long elapsed = NanoTime() - lastTime;
                    long milliSleep = (nanoPerFrame - elapsed) / 1000000;
                    if (milliSleep > 0)
                    {
                        Thread.Sleep((int)milliSleep);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Window is missing : " + ex.Message);
                    Environment.Exit(0);
                }
            }
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
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
