using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using elements;
using Image = elements.Image;
using System.IO;
using logger;
using System.Windows.Media.Imaging;
using System;

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
            Logger.RefreshFile();

            Logger.Add(eMessageType.process, "Initializing components");
            InitializeComponent();
            Logger.Add(eMessageType.completion, "Initialization complete");

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeImages();
        }



        public void InitializeImages()
        {
            Logger.Add(eMessageType.process, "Initializing images");
            imgBg.Source = new BitmapImage(new Uri(info.absolutePath + "\\" + info.files["bg"], UriKind.Absolute));
            imgFX1.Source = new BitmapImage(new Uri(info.absolutePath + "\\" + info.files["fx1right"], UriKind.Absolute));
            imgFX2.Source = new BitmapImage(new Uri(info.absolutePath + "\\" + info.files["fx2right"], UriKind.Absolute));
            Logger.Add(eMessageType.completion, "Initializing images complete");
        }



        private void GenerateJSONs(object sender, RoutedEventArgs e)
        {
            Logger.Add(eMessageType.note, "GenerateJSON pressed");

            Dictionary<string, bool> componentsSettings = GetComponentsSettings();

            Dictionary<string, List<PlayfieldItem>> playfields = new Dictionary<string, List<PlayfieldItem>>();
            Dictionary<string, Keymode> keymodes = new Dictionary<string, Keymode>();
            List<MetaDataItem> metaData = new List<MetaDataItem>();

            Logger.Add(eMessageType.process, "Making playfield, keymode and metadataitem for each mode");
            foreach (int mode in info.modes)
            {
                Logger.Add(eMessageType.value, "Mode: " + mode);
                for (int i=0; i<2; i++)
                {
                    bool sidetracks = i == 0 ? false : true;

                    Logger.Add(eMessageType.value, "Sidetracks: " + sidetracks);

                    Logger.Add(eMessageType.process, "Making playfield");
                    List<PlayfieldItem> playfield = PlayfieldItem.GetPlayfield(mode, sidetracks, componentsSettings);

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



        public Dictionary<string, bool> GetComponentsSettings()
        {
            Logger.Add(eMessageType.process, "Getting user settings");
            Dictionary<string, bool> componentsSettings = new Dictionary<string, bool>();

            componentsSettings["vidbg"] = (bool)vidbg.IsChecked;
            componentsSettings["combobg"] = (bool)combobg.IsChecked;
            componentsSettings["beam"] = (bool)beam.IsChecked;
            componentsSettings["combo"] = (bool)combo.IsChecked;
            componentsSettings["progressbar"] = (bool)progressbar.IsChecked;
            componentsSettings["accuracy"] = (bool)accuracy.IsChecked;
            componentsSettings["timegate"] = (bool)timegate.IsChecked;
            componentsSettings["keypressed"] = (bool)keypressed.IsChecked;
            componentsSettings["particles"] = (bool)particles.IsChecked;
            Logger.Add(eMessageType.value, "User settings: " + componentsSettings.ToString());

            return componentsSettings;
        }
    }
}
