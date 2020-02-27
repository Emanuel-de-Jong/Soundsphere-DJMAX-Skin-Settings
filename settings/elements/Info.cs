using System.Collections.Generic;
using System.IO;
using logger;

namespace elements
{
    public class Info
    {
        public Dictionary<string, string> files;
        public Dictionary<string, int> layers;
        public string absolutePath;
        public string skinName;
        public string soundspherePath;
        public object[] csMiddle;
        public object[] cs;
        public List<int> modes;

        public Info()
        {
            Logger.Add(eMessageType.process, "Initializing Info");

            absolutePath = Directory.GetCurrentDirectory();

            skinName = Path.GetFileName(absolutePath);
            Logger.Add(eMessageType.value, "Skin name: " + skinName);

            soundspherePath = "userdata/skins/" + skinName + "/";

            csMiddle = new object[] { 0.5, 0, 0, 0, eBinding.h.ToString() };
            cs = new object[] { 0, 0, 0, 0, eBinding.h.ToString() };

            modes = new List<int>() { 4, 5, 6, 8, 10 };

            SetFiles();
            SetLayers();
            Logger.Add(eMessageType.completion, "Initialization complete");
        }

        public void SetFiles()
        {
            files = new Dictionary<string, string>();

            Logger.Add(eMessageType.process, "Getting all file paths in current directory");
            string[] paths = Directory.GetFiles(absolutePath, "*.*", SearchOption.AllDirectories);

            Logger.Add(eMessageType.process, "Changeing the file paths to a <file name without extension, relative path from current directory> dictionary");
            foreach (string path in paths)
            {
                string name = Path.GetFileNameWithoutExtension(path);
                string shortPath = path.Substring(path.LastIndexOf(skinName) + skinName.Length + 1);
                shortPath = shortPath.Replace("\\", "/");
                files[name] = shortPath;
            }
        }

        public void SetLayers()
        {
            layers = new Dictionary<string, int>();

            Logger.Add(eMessageType.process, "Setting layers");
            layers["novidbg"] = 0;
            layers["bg"] = 1;
            layers["combobg"] = 10;
            layers["judgeline"] = 20;
            layers["fxbeam"] = 30;
            layers["beam"] = 31;
            layers["measure"] = 40;
            layers["fx2body"] = 50;
            layers["fx2tail"] = 51;
            layers["fx2head"] = 52;
            layers["fx2"] = 53; 
            layers["fx1body"] = 60;
            layers["fx1tail"] = 61;
            layers["fx1head"] = 62;
            layers["fx1"] = 63;
            layers["stbody"] = 70;
            layers["sttail"] = 71;
            layers["sthead"] = 72;
            layers["st"] = 73;
            layers["notebody"] = 80;
            layers["notetail"] = 81;
            layers["notehead"] = 82;
            layers["note"] = 83;
            layers["playfield"] = 90;
            layers["combo"] = 100;
            layers["accuracy"] = 100;
            layers["timegate"] = 100;
            layers["score"] = 100;
            layers["progressbarbg"] = 110;
            layers["progressbar"] = 111;
            layers["fxkey1"] = 120;
            layers["fxkey2"] = 121;
            layers["key"] = 122;
            layers["particle"] = 130;
            layers["fxparticle"] = 131;
            layers["stparticle"] = 132;
        }
    }
}
