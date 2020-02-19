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
    /// Interaction logic for MainWindow.xaml
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


            Keymode keymode4k = new Keymode() {
                name = info.skinName + " 4K", playfield = info.files["playfield4k"],
                images = Image.GetImages(4, false), notes = Keymode.GetNotes(4, false) };
            keymode4k.cses.Add(info.cs);

            List<PlayfieldItem> playfield4k = PlayfieldItem.GetPlayfield(4, false);

            sMetaData.Add(new MetaDataItem() { 
                name = info.skinName + " 4K", inputMode = "4key", 
                type = "json:full-v2", path = info.files["4K"] });


            ShowJSON(playfield4k);
        }

        public void ShowJSON(object objJSON)
        {
            debug.Text = JsonConvert.SerializeObject(objJSON, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}
