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
        Info info = new Info();

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
            sMetaData.Add(new MetaDataItem() { name = info.skinName + " 4K", inputMode = "4key", type = "json:full-v2", path = info.files["4K"] });

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
            s4K.name = info.skinName + " 4K";
            s4K.playfield = info.files["playfield4K"];
            s4K.cses.Add(info.cs);
            s4K.images = Keymode.GetImages(6, false);
            s4K.notes = Keymode.GetNotes(6, false, s4K.images);

            return s4K;
        }

        public List<PlayfieldItem> GetPlayfield4K()
        {
            List<PlayfieldItem> sPlayfield4K = new List<PlayfieldItem>();

            return sPlayfield4K;
        }
    }
}
