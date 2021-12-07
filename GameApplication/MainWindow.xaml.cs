using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Canvas _canvas;

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Width = SystemParameters.WorkArea.Width / 2;
            Height = SystemParameters.WorkArea.Height / 2;
            ResizeMode = ResizeMode.NoResize;
            Title = "Game with design pattern";
        }

        public void CreateCanvas()
        {
            _canvas = new Canvas();

            _canvas.RenderSize = new System.Windows.Size(Width, Height);
            _canvas.Width = Width;
            _canvas.MinHeight = Height;
            AddChild(_canvas);
        }

    }
}
