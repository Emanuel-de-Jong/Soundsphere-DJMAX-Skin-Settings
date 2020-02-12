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
            Keymode km_10K = new Keymode();
            km_10K.name = "DJMAX 10K";

            km_10K.playfield = "playfield10K.json";

            km_10K.cses.Add(
                new object[] { 0.5, 0, 0, 0, eBinding.h.ToString() }
            );

            km_10K.images.Add(
                new Image { name = "n1", path = "6K/note1.png", layer = Layer }
            );

            km_10K.notes["measure1:" + eNoteType.LongNote] =
                new Dictionary<string, NoteComponent>() {
                    {
                        eNoteComponent.Head.ToString(), 
                        new NoteComponent() {
                            cs = 1,
                            gc = new Gc {
                                x = new List<double>() { -0.222 }, y = new List<double>() { 0.699, 1 },
                                w = new List<double>() { 0.464 }, h = new List<double>() { 0 },
                                ox = new List<double>() { 0 }, oy = new List<double>() { 0 }
                            },
                            layer = Layer,
                            image = km_10K.images[0].name
                        }
                    }
                };

            showJSON(km_10K);
        }

        public void showJSON(object objJSON)
        {
            debug.Text = JsonConvert.SerializeObject(objJSON, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}
