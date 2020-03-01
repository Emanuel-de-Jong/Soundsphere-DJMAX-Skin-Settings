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
    public static class Components
    {
        public static void GenerateJSONs(Dictionary<string, bool> componentsSettings)
        {
            Logger.Add(eMessageType.note, "GenerateJSON pressed");

            Dictionary<string, List<PlayfieldItem>> playfields = new Dictionary<string, List<PlayfieldItem>>();
            Dictionary<string, Keymode> keymodes = new Dictionary<string, Keymode>();
            List<MetaDataItem> metaData = new List<MetaDataItem>();

            Logger.Add(eMessageType.process, "Making playfield, keymode and metadataitem for each mode");
            foreach ((string, bool) mode in Info.modes)
            {
                string modeName = mode.Item1;
                bool hasST = mode.Item2;

                Logger.Add(eMessageType.value, "Mode: " + modeName);
                for (int i = 0; i < (hasST ? 2 : 1); i++)
                {
                    bool sidetracks = i == 0 ? false : true;

                    Logger.Add(eMessageType.value, "Sidetracks: " + sidetracks);

                    Logger.Add(eMessageType.process, "Making playfield");
                    List<PlayfieldItem> playfield = PlayfieldItem.GetPlayfield(modeName, sidetracks, componentsSettings);

                    string keymodeName = modeName + (sidetracks ? "2st" : "");
                    string playfieldName = "playfield" + keymodeName;
                    string name = Info.skinName + " " + keymodeName;
                    string inputMode = (modeName + (sidetracks ? 2 : 0)) + "key";
                    if (modeName.Contains("10k") && sidetracks)
                    {
                        inputMode = "10key2scratch";
                    }
                    else if(modeName.Contains("4k2fx4l"))
                    {
                        inputMode = "4bt2fx2laserleft2laserright";
                    }

                    Logger.Add(eMessageType.process, "Making keymode");
                    Keymode keymode = new Keymode()
                    {
                        name = name,
                        playfield = Info.files[playfieldName],
                        images = Image.GetImages(modeName, sidetracks),
                        notes = Keymode.GetNotes(modeName, sidetracks),
                        cses = new List<object[]>() { Info.csMiddle }
                    };

                    Logger.Add(eMessageType.process, "Making metadataitem");
                    MetaDataItem metaDataItem = new MetaDataItem()
                    {
                        name = name,
                        inputMode = inputMode,
                        type = "json:full-v2",
                        path = Info.files[keymodeName]
                    };

                    playfields[playfieldName] = playfield;
                    keymodes[keymodeName] = keymode;
                    metaData.Add(metaDataItem);
                }
            }
            Logger.Add(eMessageType.completion, "Making playfield, keymode and metadataitems for each mode complete");

            CreateJSONs(playfields, keymodes, metaData);
        }



        public static void CreateJSONs(Dictionary<string, List<PlayfieldItem>> playfields, Dictionary<string, Keymode> keymodes, List<MetaDataItem> metaData)
        {
            Logger.Add(eMessageType.process, "Creating JSONs");
            Logger.Add(eMessageType.process, "Writing to playfield jsons");
            foreach (KeyValuePair<string, List<PlayfieldItem>> playfield in playfields)
            {
                File.WriteAllText(Info.files[playfield.Key], JsonConvert.SerializeObject(playfield.Value, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                }));
            }

            Logger.Add(eMessageType.process, "Writing to keymode jsons");
            foreach (KeyValuePair<string, Keymode> keymode in keymodes)
            {
                File.WriteAllText(Info.files[keymode.Key], JsonConvert.SerializeObject(keymode.Value, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                }));
            }

            Logger.Add(eMessageType.process, "Writing to metadata json");
            File.WriteAllText(Info.files["metadata"], JsonConvert.SerializeObject(metaData, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            }));
            Logger.Add(eMessageType.completion, "Creating JSONs complete");
        }
    }
}
