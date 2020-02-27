using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using logger;

namespace elements
{
    public class Image
    {
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
            Logger.Add(eMessageType.process, "Getting images for keymode");
            List<Image> images = new List<Image>();


            images.Add(new Image() { name = "measure", path = Info.files["measure"], layer = Info.layers["measure"] });


            if (keymode == 8)
            {
                for (int i = 1; i <= 2; i++)
                {
                    string side = i == 1 ? "left" : "right";
                    images.Add(new Image() { name = "fx" + side + "body", path = Info.files["fx" + side + "body"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = Info.layers["fx1body"] });
                    images.Add(new Image() { name = "fx" + side + "tail", path = Info.files["fx" + side + "tail"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = Info.layers["fx1tail"] });
                    images.Add(new Image() { name = "fx" + side + "head", path = Info.files["fx" + side + "head"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = Info.layers["fx1head"] });
                    images.Add(new Image() { name = "fx" + side, path = Info.files["fx" + side], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = Info.layers["fx1"] });
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
                        images.Add(new Image() { name = "fx" + fxCount + side + "body", path = Info.files["fx" + fxCount + side + "body"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = Info.layers["fx" + fxCount + "body"] });
                        images.Add(new Image() { name = "fx" + fxCount + side + "tail", path = Info.files["fx" + fxCount + side + "tail"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = Info.layers["fx" + fxCount + "tail"] });
                        images.Add(new Image() { name = "fx" + fxCount + side + "head", path = Info.files["fx" + fxCount + side + "head"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = Info.layers["fx" + fxCount + "head"] });
                        images.Add(new Image() { name = "fx" + fxCount + side, path = Info.files["fx" + fxCount + side], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = Info.layers["fx" + fxCount] });
                    }
                }
            }


            if (sidetracks)
            {
                images.Add(new Image() { name = "stbody", path = Info.files["stbody"], layer = Info.layers["stbody"] });
                images.Add(new Image() { name = "sttail", path = Info.files["sttail"], layer = Info.layers["sttail"] });
                images.Add(new Image() { name = "sthead", path = Info.files["sthead"], layer = Info.layers["sthead"] });
                images.Add(new Image() { name = "st", path = Info.files["st"], layer = Info.layers["st"] });
            }

            int noteKey = keymode >= 6 ? 6 : keymode;
            for (int i = 1; i <= 2; i++)
            {
                string noteCount = i.ToString();
                images.Add(new Image() { name = "note" + noteCount + "body", path = Info.files["note" + noteCount + "body" + noteKey + "k"], layer = Info.layers["notebody"] });
                images.Add(new Image() { name = "note" + noteCount + "tail", path = Info.files["note" + noteCount + "tail" + noteKey + "k"], layer = Info.layers["notetail"] });
                images.Add(new Image() { name = "note" + noteCount + "head", path = Info.files["note" + noteCount + "head" + noteKey + "k"], layer = Info.layers["notehead"] });
                images.Add(new Image() { name = "note" + noteCount, path = Info.files["note" + noteCount + noteKey + "k"], layer = Info.layers["note"] });
            }

            Logger.Add(eMessageType.completion, "Getting images for keymode complete");
            return images;
        }
    }
}
