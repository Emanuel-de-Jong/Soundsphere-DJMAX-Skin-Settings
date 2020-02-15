using System;
using System.Collections.Generic;

namespace elements
{
    public class Keymode
    {
        public string name { get; set; }
        public string playfield { get; set; }
        public List<object[]> cses { get; set; }
        public List<Image> images { get; set; }
        public Dictionary<string, Dictionary<string, NoteComponent>> notes { get; set; }

        public Keymode()
        {
            name = "";
            playfield = "";
            cses = new List<object[]>();
            images = new List<Image>();
            notes = new Dictionary<string, Dictionary<string, NoteComponent>>();
        }

        public static List<Image> GetImages(int notes = 10, bool sidetracks = false)
        {
            List<Image> images = new List<Image>();


            string dir = "";
            if (notes >= 6)
            {
                dir = "6K";
            }
            else
            {
                dir = notes.ToString() + "K";
            }


            if (notes == 8)
            {
                for (int i = 1; i <= 2; i++)
                {
                    string side = i == 1 ? "left" : "right";
                    images.Add(new Image() { name = "fx" + side + "b", path = "resources/8K/fx" + side + "body.png", blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = sLayer.GetAndIncrement() });
                    images.Add(new Image() { name = "fx" + side + "h", path = "resources/8K/fx" + side + "head.png", blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = sLayer.GetAndIncrement() });
                    images.Add(new Image() { name = "fx" + side + "t", path = "resources/8K/fx" + side + "tail.png", blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = sLayer.GetAndIncrement() });
                    images.Add(new Image() { name = "fx" + side, path = "resources/8K/fx" + side + ".png", blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = sLayer.GetAndIncrement() });
                }
            }
            else if (notes == 10)
            {
                for (int i = 2; i >= 1; i--)
                {
                    string fxCount = i.ToString();
                    for (int j = 1; j <= 2; j++)
                    {
                        string side = j == 1 ? "left" : "right";
                        images.Add(new Image() { name = "fx" + fxCount + side + "b", path = "resources/10K/fx" + fxCount + side + "body.png", blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = sLayer.GetAndIncrement() });
                        images.Add(new Image() { name = "fx" + fxCount + side + "h", path = "resources/10K/fx" + fxCount + side + "head.png", blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = sLayer.GetAndIncrement() });
                        images.Add(new Image() { name = "fx" + fxCount + side + "t", path = "resources/10K/fx" + fxCount + side + "tail.png", blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = sLayer.GetAndIncrement() });
                        images.Add(new Image() { name = "fx" + fxCount + side, path = "resources/10K/fx" + fxCount + side + ".png", blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = sLayer.GetAndIncrement() });
                    }
                }
            }


            if (sidetracks)
            {
                images.Add(new Image() { name = "stb", path = "resources/stbody.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "sth", path = "resources/sthead.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "stt", path = "resources/sttail.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "st", path = "resources/st.png", layer = sLayer.GetAndIncrement() });
            }


            for (int i=1; i <=2; i++)
            {
                string noteCount = i.ToString();
                images.Add(new Image() { name = "n" + noteCount + "b", path = "resources/" + dir + "/note" + noteCount + "body.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "n" + noteCount + "h", path = "resources/" + dir + "/note" + noteCount + "head.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "n" + noteCount + "t", path = "resources/" + dir + "/note" + noteCount + "tail.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "n" + noteCount, path = "resources/" + dir + "/note" + noteCount + ".png", layer = sLayer.GetAndIncrement() });
            }


            return images;
        }
    }
}
