using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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

        public static List<Image> GetImages(int keymode = 10, bool sidetracks = false)
        {
            List<Image> images = new List<Image>();


            images.Add(new Image() { name = "measure", path = "resources/measure", layer = sLayer.GetAndIncrement() });


            if (keymode == 8)
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
            else if (keymode == 10)
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


            string dir = "resources/";
            if (keymode >= 6)
            {
                dir += "6K";
            }
            else
            {
                dir += keymode.ToString() + "K";
            }

            for (int i=1; i <=2; i++)
            {
                string noteCount = i.ToString();
                images.Add(new Image() { name = "n" + noteCount + "b", path = dir + "/note" + noteCount + "body.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "n" + noteCount + "h", path = dir + "/note" + noteCount + "head.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "n" + noteCount + "t", path = dir + "/note" + noteCount + "tail.png", layer = sLayer.GetAndIncrement() });
                images.Add(new Image() { name = "n" + noteCount, path = dir + "/note" + noteCount + ".png", layer = sLayer.GetAndIncrement() });
            }


            return images;
        }

        public static Dictionary<string, Dictionary<string, NoteComponent>> GetNotes(int keymode, bool sidetracks, List<Image> images)
        {
            Dictionary<string, Dictionary<string, NoteComponent>> notes = new Dictionary<string, Dictionary<string, NoteComponent>>();

            string dir = "settingsresources/positions/positions" + keymode.ToString() + "K";
            dir += sidetracks ? "2ST" : "";
            dir += ".json";
            string json = File.ReadAllText(dir);
            var positions = JsonConvert.DeserializeObject<Positions>(json);

            var measure1Pos = positions.measure1["ShortNote"]["Head"];
            notes["measure1:" + eNoteType.ShortNote] =
                new Dictionary<string, NoteComponent>() {
                    {
                        eNoteComponent.Head.ToString(),
                        new NoteComponent() {
                            cs = 1,
                            gc = new Gc {
                                x = measure1Pos["x"], y = measure1Pos["y"],
                                w = measure1Pos["w"], h = measure1Pos["h"],
                                ox = measure1Pos["ox"], oy = measure1Pos["oy"]
                            },
                            layer = sLayer.GetAndIncrement(),
                            image = images[0].name
                        }
                    }
                };

            return notes;
        }
    }
}
