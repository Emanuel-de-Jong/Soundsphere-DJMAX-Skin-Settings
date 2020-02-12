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
using Newtonsoft.Json.Converters;
using Image = elements.Image;

namespace settings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml test
    /// </summary>
    public partial class MainWindow : Window
    {
        private int layer = 1;

        public int Layer
        {
            get
            {
                return layer++;
            }
            set
            {
                layer = 0;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void GenerateJSON(object sender, RoutedEventArgs e)
        {
            Cs cs = new Cs { x = 0.5, y = 0, a = 0, b = 0, binding = eBinding.h };

            Image n1 = new Image { name = "n1", path = "6K/note1.png", layer = Layer };
            Image n1t = new Image { name = "n1t", path = "6K/note1tail.png", layer = Layer, blendAlphaMode = eBlendAlphaMode.alphamultiply };

            Dictionary<string, NoteComponent> measure1 = new Dictionary<string, NoteComponent>()
            {
                { "Head", new NoteComponent()
                {
                    cs = 1,
                    gc = new Gc {
                        x = new List<double>() { -0.222 }, y = new List<double>() { 0.699, 1 },
                        w = new List<double>() { 0.464 }, h = new List<double>() { 0 },
                        ox = new List<double>() { 0 }, oy = new List<double>() { 0 }
                    },
                    sb = new Sb(),
                    layer = 0,
                    image = "white"
                }}
            };


            Keymode km_10K = new Keymode
            { name = "DJMAX 10K", playfield = "playfield10K.json", cses = new List<object[]> { cs.getCsAsArr() }, 
                images = new List<Image> { n1, n1t }, notes = new Dictionary<string, Dictionary<string, NoteComponent>>() { { "measure1:ShortNote", measure1 } }
            };

            showJSON(km_10K);
        }

        public void showJSON(object objJSON)
        {
            debug.Text = JsonConvert.SerializeObject(objJSON, Formatting.Indented, new JsonSerializerSettings { 
                NullValueHandling = NullValueHandling.Ignore 
            });
        }
    }
}
