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
            System.Windows.Shapes.Rectangle rect;
            rect = new System.Windows.Shapes.Rectangle();
            rect.Stroke = new SolidColorBrush(Colors.Black);
            rect.Fill = new SolidColorBrush(Colors.Black);
            rect.Width=200;
            rect.Height=200;

            Canvas.SetLeft(rect, 5*96-200-10);
            Canvas.SetTop(rect, 3*96-200-10);
            canvas.Children.Add(rect);



            canvas.Height = 3 * 96;
            canvas.Width = 5 * 96;
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
    }
}
