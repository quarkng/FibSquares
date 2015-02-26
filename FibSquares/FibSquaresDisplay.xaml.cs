using System;
using System.Collections.Generic;
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

namespace FibSquares
{
    /// <summary>
    /// Interaction logic for FibSquaresDisplay.xaml
    /// </summary>
    public partial class FibSquaresDisplay : Window
    {
        public FibSquaresDisplay()
        {
            InitializeComponent();
        }


        public void DrawSquares( List<SquareData> squares )
        {
            float maxX = 0;
            float maxY = 0;

            foreach( var s in squares )
            {
                AddSquare(s);
                maxX = (s.Left + s.Size > maxX) ? (s.Left + s.Size) : maxX;
                maxY = (s.Top + s.Size > maxY) ? (s.Top + s.Size) : maxY;
            }

            canvas.Height = maxY;
            canvas.Width = maxX;
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        private void AddSquare(SquareData square)
        {
            Rectangle rect = new Rectangle();
            rect.Stroke = rect.Fill = new SolidColorBrush(square.Fill);
            rect.Width = rect.Height = square.Size;

            Canvas.SetLeft(rect, square.Left);
            Canvas.SetTop(rect, square.Top);
            canvas.Children.Add(rect);
        }


    }
}
