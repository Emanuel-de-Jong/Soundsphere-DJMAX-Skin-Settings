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
using System.IO;

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

            Dictionary<string, List<PlayfieldItem>> playfields = new Dictionary<string, List<PlayfieldItem>>();
            Dictionary<string, Keymode> keymodes = new Dictionary<string, Keymode>();
            List<MetaDataItem> metaData = new List<MetaDataItem>();

            List<int> modes = new List<int>() { 4, 5, 6, 8 };
            foreach(int mode in modes)
            {
                for(int i=0; i<2; i++)
                {
                    bool sidetracks = i == 0 ? false : true;

                    List<PlayfieldItem> playfield = PlayfieldItem.GetPlayfield(mode, sidetracks, userSettings);

                    string name = info.skinName + " " + mode + "K" + (sidetracks ? "2ST" : "");
                    string playfieldName = "playfield" + mode + "k" + (sidetracks ? "2st" : "");
                    string keymodeName = mode + "k" +(sidetracks ? "2st" : "");
                    int inputMode = mode + (sidetracks ? 2 : 0);

                    Keymode keymode = new Keymode()
                    {
                        name = name,
                        playfield = info.files[playfieldName],
                        images = Image.GetImages(mode, sidetracks),
                        notes = Keymode.GetNotes(mode, sidetracks),
                        cses = new List<object[]>() { info.csMiddle }
                    };
                    
                    MetaDataItem metaDataItem = new MetaDataItem()
                    {
                        name = name,
                        inputMode = inputMode + "key",
                        type = "json:full-v2",
                        path = info.files[keymodeName]
                    };

                    playfields[playfieldName] = playfield;
                    keymodes[keymodeName] = keymode;
                    metaData.Add(metaDataItem);
                }
            }

            CreateJSONs(playfields, keymodes, metaData);
        }

        public void CreateJSONs(Dictionary<string, List<PlayfieldItem>> playfields, Dictionary<string, Keymode> keymodes, List<MetaDataItem> metaData)
        {
            foreach(KeyValuePair<string, List<PlayfieldItem>> playfield in playfields)
            {
                File.WriteAllText(info.files[playfield.Key], JsonConvert.SerializeObject(playfield.Value, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                }));
            }

            foreach (KeyValuePair<string, Keymode> keymode in keymodes)
            {
                File.WriteAllText(info.files[keymode.Key], JsonConvert.SerializeObject(keymode.Value, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                }));
            }

            File.WriteAllText(info.files["metadata"], JsonConvert.SerializeObject(metaData, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            }));
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
