using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using elements;
using Image = elements.Image;
using System.IO;
using logger;

namespace settings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Logger.Add(eMessageType.other, "test");
    public partial class MainWindow : Window
    {
        Info info = new Info();

        public MainWindow()
        {
            Logger.Add(eMessageType.process, "Initializing components");
            InitializeComponent();
            Logger.Add(eMessageType.completion, "Initialization complete");

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            Logger.Add(eMessageType.process, "Getting current directory");
            string currentDir = Directory.GetCurrentDirectory() + "\\";
            Logger.Add(eMessageType.value, "Current directory: " + currentDir);

            Logger.FilePath = currentDir + info.files["log"];

            //bgimg.Source = new BitmapImage(new Uri(currentDir + info.files["bg"], UriKind.Absolute));
        }

        private void GenerateJSON(object sender, RoutedEventArgs e)
        {
            Logger.Add(eMessageType.note, "GenerateJSON pressed");

            Dictionary<string, bool> userSettings = GetUserSettings();

            Dictionary<string, List<PlayfieldItem>> playfields = new Dictionary<string, List<PlayfieldItem>>();
            Dictionary<string, Keymode> keymodes = new Dictionary<string, Keymode>();
            List<MetaDataItem> metaData = new List<MetaDataItem>();

            Logger.Add(eMessageType.process, "Listing modes");
            List<int> modes = new List<int>() { 4, 5, 6, 8, 10 };
            Logger.Add(eMessageType.value, "Modes: " + modes.ToString());

            Logger.Add(eMessageType.process, "Making playfield, keymode and metadataitem for each mode");
            foreach (int mode in modes)
            {
                Logger.Add(eMessageType.value, "Mode: " + mode);
                for (int i=0; i<2; i++)
                {
                    bool sidetracks = i == 0 ? false : true;

                    Logger.Add(eMessageType.value, "Sidetracjs: " + sidetracks);

                    Logger.Add(eMessageType.process, "Making playfield");
                    List<PlayfieldItem> playfield = PlayfieldItem.GetPlayfield(mode, sidetracks, userSettings);

                    string name = info.skinName + " " + mode + "K" + (sidetracks ? "2ST" : "");
                    string playfieldName = "playfield" + mode + "k" + (sidetracks ? "2st" : "");
                    string keymodeName = mode + "k" +(sidetracks ? "2st" : "");
                    string inputMode = (mode + (sidetracks ? 2 : 0)) + "key";
                    if(mode == 10 && sidetracks)
                        inputMode = "10key2scratch";

                    Logger.Add(eMessageType.process, "Making keymode");
                    Keymode keymode = new Keymode()
                    {
                        name = name,
                        playfield = info.files[playfieldName],
                        images = Image.GetImages(mode, sidetracks),
                        notes = Keymode.GetNotes(mode, sidetracks),
                        cses = new List<object[]>() { info.csMiddle }
                    };

                    Logger.Add(eMessageType.process, "Making metadataitem");
                    MetaDataItem metaDataItem = new MetaDataItem()
                    {
                        name = name,
                        inputMode = inputMode,
                        type = "json:full-v2",
                        path = info.files[keymodeName]
                    };

                    playfields[playfieldName] = playfield;
                    keymodes[keymodeName] = keymode;
                    metaData.Add(metaDataItem);
                }
            }
            Logger.Add(eMessageType.completion, "Making playfield, keymode and metadataitems for each mode complete");

            CreateJSONs(playfields, keymodes, metaData);
        }

        public void CreateJSONs(Dictionary<string, List<PlayfieldItem>> playfields, Dictionary<string, Keymode> keymodes, List<MetaDataItem> metaData)
        {
            Logger.Add(eMessageType.process, "Creating JSONs");
            Logger.Add(eMessageType.process, "Writing to playfield jsons");
            foreach (KeyValuePair<string, List<PlayfieldItem>> playfield in playfields)
            {
                File.WriteAllText(info.files[playfield.Key], JsonConvert.SerializeObject(playfield.Value, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                }));
            }

            Logger.Add(eMessageType.process, "Writing to keymode jsons");
            foreach (KeyValuePair<string, Keymode> keymode in keymodes)
            {
                File.WriteAllText(info.files[keymode.Key], JsonConvert.SerializeObject(keymode.Value, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                }));
            }

            Logger.Add(eMessageType.process, "Writing to metadata json");
            File.WriteAllText(info.files["metadata"], JsonConvert.SerializeObject(metaData, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            }));
            Logger.Add(eMessageType.completion, "Creating JSONs complete");
        }

        public Dictionary<string, bool> GetUserSettings()
        {
            Logger.Add(eMessageType.process, "Getting user settings");
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
            Logger.Add(eMessageType.value, "User settings: " + userSettings.ToString());

            return userSettings;
        }

        private void ChangeBGOpacity(object sender, RoutedEventArgs e)
        {

        }
        
        private void Change4FXImages(object sender, RoutedEventArgs e)
        {

        }

        private void InsertCustomScores(object sender, RoutedEventArgs e)
        {

        }

        private void InsertJudgeTable(object sender, RoutedEventArgs e)
        {

        }
    }
}
