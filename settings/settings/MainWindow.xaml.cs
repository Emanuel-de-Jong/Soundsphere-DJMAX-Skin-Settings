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
            Dictionary<string, bool> userSettings = GetUserSettings();

            List<MetaDataItem> sMetaData = new List<MetaDataItem>();

            Keymode keymode4k = new Keymode() {
                name = info.skinName + " 4K", playfield = info.files["playfield4k"],
                images = Image.GetImages(4, false), notes = Keymode.GetNotes(4, false) };
            keymode4k.cses.Add(info.csMiddle);

            List<PlayfieldItem> playfield4k = PlayfieldItem.GetPlayfield(4, false, userSettings);

            sMetaData.Add(new MetaDataItem() { 
                name = info.skinName + " 4K", inputMode = "4key", 
                type = "json:full-v2", path = info.files["4k"] });


            ShowJSON(playfield4k);
        }

        public void ShowJSON(object objJSON)
        {
            debug.Text = JsonConvert.SerializeObject(objJSON, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        public Dictionary<string, bool> GetUserSettings()
        {
            Dictionary<string, bool> userSettings = new Dictionary<string, bool>();

            userSettings["vidbg"] = (bool)vidbg.IsChecked;
            userSettings["combobg"] = (bool)combobg.IsChecked;
            userSettings["beam"] = (bool)beam.IsChecked;
            userSettings["combo"] = (bool)combo.IsChecked;
            userSettings["progressbar"] = (bool)progressbar.IsChecked;
            userSettings["accuracy"] = (bool)accuracy.IsChecked;
            userSettings["timegate"] = (bool)timegate.IsChecked;
            userSettings["keypressed"] = (bool)keypressed.IsChecked;
            userSettings["particles"] = (bool)particles.IsChecked;

            return userSettings;
        }
    }
}
