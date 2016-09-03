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

namespace Color_Hex_RGB
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

        private void btnHexToRGB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var hexColor = tbHexColor.Text.Trim();
                var hexColorRed = hexColor.Substring(0, 2);
                var hexColorGreen = hexColor.Substring(2, 2);
                var hexColorBlue = hexColor.Substring(4, 2);
               
                var redColor = Convert.ToInt32(hexColorRed, 16);
                var greenColor = Convert.ToInt32(hexColorGreen, 16);
                var blueColor = Convert.ToInt32(hexColorBlue, 16);

                tbRed.Text=redColor.ToString();
                tbGreen.Text = greenColor.ToString();
                tbBlue.Text = blueColor.ToString();

                BrushConverter brushConverter = new BrushConverter();

                borderColor.BorderBrush = (Brush)brushConverter.ConvertFromString("#" + hexColor);
            }
            catch (Exception)
            {

                MessageBox.Show("请输入正确的值");
            }
            
        }

        private void btnRGBToHex_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var redColor = NumberTooBig(int.Parse(tbRed.Text.Trim()));
                var greenColor = NumberTooBig(int.Parse(tbGreen.Text.Trim()));
                var blueColor = NumberTooBig(int.Parse(tbBlue.Text.Trim()));

                tbRed.Text = redColor.ToString();
                tbGreen.Text = greenColor.ToString();
                tbBlue.Text = blueColor.ToString();

                string hexColor = Convert.ToString(redColor, 16);
                hexColor += Convert.ToString(greenColor, 16);
                hexColor += Convert.ToString(blueColor, 16);

                tbHexColor.Text = hexColor.ToString();

                Brush brush = new SolidColorBrush(Color.FromRgb(Convert.ToByte(redColor), Convert.ToByte(greenColor), Convert.ToByte(blueColor)));

                borderColor.BorderBrush = brush;
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的值");
            }
            
        }

        private void tbHexColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbHexColor.Text.Length==6)
            {
                btnHexToRGB.IsEnabled = true;
            }
        }

        private int NumberTooBig(int number) {
            if (number>255)
            {
                number = 255;
            }return number;
        }
    }
}
