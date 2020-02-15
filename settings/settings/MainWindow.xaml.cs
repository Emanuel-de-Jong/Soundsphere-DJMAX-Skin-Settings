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
        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void GenerateJSON(object sender, RoutedEventArgs e)
        {
            List<MetaDataItem> sMetaData = new List<MetaDataItem>();

            Keymode s4K = Get4K();
            List<PlayfieldItem> sPlayfield4K = GetPlayfield4K();
            sMetaData.Add(new MetaDataItem() { name = "DJMAX 4K", inputMode = "4key", type = "json:full-v2", path = "4K.json" });
            sLayer.Layer = 1;







            Keymode km_10K = new Keymode();
            km_10K.name = "DJMAX 10K";

            km_10K.playfield = "playfield10K.json";

            km_10K.cses.Add(
                new object[] { 0.5, 0, 0, 0, eBinding.h.ToString() }
            );

            km_10K.images.Add(
                new Image { name = "n1", path = "6K/note1.png", layer = sLayer.GetAndIncrement() }
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
                            layer = sLayer.GetAndIncrement(),
                            image = km_10K.images[0].name
                        }
                    }
                };

            ShowJSON(s4K);
        }

        public void ShowJSON(object objJSON)
        {
            debug.Text = JsonConvert.SerializeObject(objJSON, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        public Keymode Get4K()
        {
            Keymode s4K = new Keymode();
            s4K.name = "DJMAX 4K";
            s4K.playfield = "playfield4K.json";
            s4K.cses.Add(sCs.Cs);
            s4K.images = Keymode.GetImages(10, false);

            return s4K;
        }

        public List<PlayfieldItem> GetPlayfield4K()
        {
            List<PlayfieldItem> sPlayfield4K = new List<PlayfieldItem>();

            return sPlayfield4K;
        }
    }
}
