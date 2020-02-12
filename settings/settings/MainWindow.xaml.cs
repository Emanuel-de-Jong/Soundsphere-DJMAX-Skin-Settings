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
using Newtonsoft.Json;
using elements;

namespace settings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml test
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void GenerateJSON(object sender, RoutedEventArgs e)
        {
            ImagesImage n1 = new ImagesImage { name = "n1", path = "6K/note1.png" };
            ImagesImage n1t = new ImagesImage { name = "n1t", path = "6K/note1tail.png" };

            Cs cs = new Cs { num1 = 0.5, num2 = 0, num3 = 0, num4 = 0, orientation = "h" };

            Keymode km_10K = new Keymode { name = "DJMAX 10K", playfield = "playfield10K.json", cses = new List<object[]> { cs.getCsAsArr() }, images = new List<ImagesImage> { n1, n1t } };

            debug.Text = JsonConvert.SerializeObject(km_10K);
        }
    }
}
