﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace elements
{
    public class Info
    {
        public string skinName;
        public object[] cs;
        public Dictionary<string, string> files;
        public Dictionary<string, int> layers;

        public Info()
        {
            skinName = "DJMAXthing";
            cs = new object[] { 0.5, 0, 0, 0, eBinding.h.ToString() };
            SetFiles();
            SetLayers();
        }

        public void SetFiles()
        {
            string[] paths = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.*", SearchOption.AllDirectories);
            foreach (string path in paths)
            {
                string name = Path.GetFileNameWithoutExtension(path);
                string shortPath = path.Substring(path.LastIndexOf(skinName) + skinName.Length + 1);
                files[name] = shortPath;
            }
        }

        public void SetLayers()
        {
            layers["bg"] = 0;
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
            layers["timegate"] = 100;
            layers["combo"] = 100;
            layers["score"] = 100;
            layers["accuracy"] = 100;
            layers["keynote"] = 100;
            layers["progressbarbg"] = 100;
            layers["keynotepressed"] = 101;
            layers["progressbar"] = 101;
            layers["fxparticle"] = 110;
            layers["stparticle"] = 111;
            layers["particle"] = 112;
        }
    }
}