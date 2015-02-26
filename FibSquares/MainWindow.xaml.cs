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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FibSquares
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            txtStaBar.Text = "Working...";

            // Trim the strings
            txtHorizontal.Text = txtHorizontal.Text.Trim();
            txtVerticle.Text = txtVerticle.Text.Trim();

            float h;
            if( ! Single.TryParse(txtHorizontal.Text, out h) )
            {
                txtStaBar.Text = "Horizontal value is not a number";
                return;
            }

            float v;
            if (!Single.TryParse(txtVerticle.Text, out v))
            {
                txtStaBar.Text = "Vertical value is not a number";
                return;
            }

            btnDraw.IsEnabled = false;
            

            FibSquaresDisplay disp = new FibSquaresDisplay();
            disp.DrawSquares(null);
            disp.ShowDialog();


            btnDraw.IsEnabled = true;
            txtStaBar.Text = "";
        }
    }
}
