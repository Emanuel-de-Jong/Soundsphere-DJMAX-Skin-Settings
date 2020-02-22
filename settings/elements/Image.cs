using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace elements
{
    public class Image
    {
        [JsonIgnore]
        static Info info = new Info();

        public string name { get; set; }
        public string path { get; set; }
        public int layer { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public eBlendMode? blendMode { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public eBlendAlphaMode? blendAlphaMode { get; set; }

        public Image()
        {
            name = "";
            path = "";
            layer = 0;
        }

        public static List<Image> GetImages(int keymode = 10, bool sidetracks = false)
        {
            List<Image> images = new List<Image>();


            images.Add(new Image() { name = "measure", path = info.files["measure"], layer = info.layers["measure"] });


            if (keymode == 8)
            {
                for (int i = 1; i <= 2; i++)
                {
                    string side = i == 1 ? "left" : "right";
                    images.Add(new Image() { name = "fx" + side + "body", path = info.files["fx" + side + "body"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx1body"] });
                    images.Add(new Image() { name = "fx" + side + "tail", path = info.files["fx" + side + "tail"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx1tail"] });
                    images.Add(new Image() { name = "fx" + side + "head", path = info.files["fx" + side + "head"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx1head"] });
                    images.Add(new Image() { name = "fx" + side, path = info.files["fx" + side], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx1"] });
                }
            }
            else if (keymode == 10)
            {
                for (int i = 2; i >= 1; i--)
                {
                    string fxCount = i.ToString();
                    for (int j = 1; j <= 2; j++)
                    {
                        string side = j == 1 ? "left" : "right";
                        images.Add(new Image() { name = "fx" + fxCount + side + "body", path = info.files["fx" + fxCount + side + "body"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx" + fxCount + "body"] });
                        images.Add(new Image() { name = "fx" + fxCount + side + "tail", path = info.files["fx" + fxCount + side + "tail"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx" + fxCount + "tail"] });
                        images.Add(new Image() { name = "fx" + fxCount + side + "head", path = info.files["fx" + fxCount + side + "head"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx" + fxCount + "head"] });
                        images.Add(new Image() { name = "fx" + fxCount + side, path = info.files["fx" + fxCount + side], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx" + fxCount] });
                    }
                }
            }


            if (sidetracks)
            {
                images.Add(new Image() { name = "stbody", path = info.files["stbody"], layer = info.layers["stbody"] });
                images.Add(new Image() { name = "sttail", path = info.files["sttail"], layer = info.layers["sttail"] });
                images.Add(new Image() { name = "sthead", path = info.files["sthead"], layer = info.layers["sthead"] });
                images.Add(new Image() { name = "st", path = info.files["st"], layer = info.layers["st"] });
            }

            int noteKey = keymode >= 6 ? 6 : keymode;
            for (int i = 1; i <= 2; i++)
            {
                string noteCount = i.ToString();
                images.Add(new Image() { name = "note" + noteCount + "body", path = info.files["note" + noteCount + "body" + noteKey + "k"], layer = info.layers["notebody"] });
                images.Add(new Image() { name = "note" + noteCount + "tail", path = info.files["note" + noteCount + "tail" + noteKey + "k"], layer = info.layers["notetail"] });
                images.Add(new Image() { name = "note" + noteCount + "head", path = info.files["note" + noteCount + "head" + noteKey + "k"], layer = info.layers["notehead"] });
                images.Add(new Image() { name = "note" + noteCount, path = info.files["note" + noteCount + noteKey + "k"], layer = info.layers["note"] });
            }


            return images;
        }
    }
}
