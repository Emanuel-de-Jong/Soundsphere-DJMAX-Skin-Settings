using System;
using System.Collections.Generic;
using System.IO;
using logger;

namespace elements
{
    public static class Info
    {
        public static string absolutePath = Directory.GetCurrentDirectory();
        public static string skinName = Path.GetFileName(absolutePath);
        public static string soundspherePath = "userdata/skins/" + skinName + "/";
        public static object[] cs = new object[] { 0.5, 0, 0, 0, eBinding.h.ToString() };
        public static List<(string, bool)> modes = new List<(string, bool)>() { ("4k", true), ("5k", true), ("6k", true), ("8k", true), ("10k", true), ("10kfade", true) }; // , ("4k2fx4l", true), ("4k2fx4lfade", true)
        public static Dictionary<string, string> files = SetFiles();
        public static Dictionary<string, int> layers = SetLayers();


        public static Dictionary<string, string> SetFiles()
        {
            Dictionary<string, string> tempFiles = new Dictionary<string, string>();

            Logger.Add(eMessageType.process, "Getting all file paths in current directory");
            string[] paths = Directory.GetFiles(absolutePath, "*.*", SearchOption.AllDirectories);

            Logger.Add(eMessageType.process, "Changeing the file paths to a <file name without extension, relative path from current directory> dictionary");
            foreach (string path in paths)
            {
                string name = Path.GetFileNameWithoutExtension(path);
                string shortPath = path.Substring(path.LastIndexOf(skinName) + skinName.Length + 1);
                shortPath = shortPath.Replace("\\", "/");
                tempFiles[name] = shortPath;
            }

            return tempFiles;
        }

        public static Dictionary<string, int> SetLayers()
        {
            Dictionary<string, int> tempLayers = new Dictionary<string, int>();

            Logger.Add(eMessageType.process, "Setting layers");
            tempLayers["novidbg"] = 0;
            tempLayers["bg"] = 1;
            tempLayers["combobg"] = 10;
            tempLayers["judgeline"] = 20;
            tempLayers["fxbeam"] = 30;
            tempLayers["beam"] = 31;
            tempLayers["measure"] = 40;
            tempLayers["fx2body"] = 50;
            tempLayers["fx2tail"] = 51;
            tempLayers["fx2head"] = 52;
            tempLayers["fx2"] = 53; 
            tempLayers["fx1body"] = 60;
            tempLayers["fx1tail"] = 61;
            tempLayers["fx1head"] = 62;
            tempLayers["fx1"] = 63;
            tempLayers["stbody"] = 70;
            tempLayers["sttail"] = 71;
            tempLayers["sthead"] = 72;
            tempLayers["st"] = 73;
            tempLayers["notebody"] = 80;
            tempLayers["notetail"] = 81;
            tempLayers["notehead"] = 82;
            tempLayers["note"] = 83;
            tempLayers["playfield"] = 90;
            tempLayers["combo"] = 100;
            tempLayers["accuracy"] = 100;
            tempLayers["timegate"] = 100;
            tempLayers["score"] = 100;
            tempLayers["progressbarbg"] = 110;
            tempLayers["progressbar"] = 111;
            tempLayers["fxkey1"] = 120;
            tempLayers["fxkey2"] = 121;
            tempLayers["key"] = 122;
            tempLayers["particle"] = 130;
            tempLayers["fxparticle"] = 131;
            tempLayers["stparticle"] = 132;

            return tempLayers;
        }
    }
}
