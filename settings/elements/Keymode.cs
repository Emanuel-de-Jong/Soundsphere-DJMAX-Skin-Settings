using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace elements
{
    public class Keymode
    {
        static Info info = new Info();

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


            images.Add(new Image() { name = "measure", path = info.files["measure"], layer = info.layers["measure"] });


            if (keymode == 8)
            {
                for (int i = 1; i <= 2; i++)
                {
                    string side = i == 1 ? "left" : "right";
                    images.Add(new Image() { name = "fx1" + side + "body", path = info.files["fx1" + side + "body"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx1body"] });
                    images.Add(new Image() { name = "fx1" + side + "tail", path = info.files["fx1" + side + "tail"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx1tail"] });
                    images.Add(new Image() { name = "fx1" + side + "head", path = info.files["fx1" + side + "head"], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx1head"] });
                    images.Add(new Image() { name = "fx1" + side, path = info.files["fx1" + side], blendAlphaMode = eBlendAlphaMode.alphamultiply, layer = info.layers["fx1"] });
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
            for (int i=1; i <=2; i++)
            {
                string noteCount = i.ToString();
                images.Add(new Image() { name = "note" + noteCount + "body", path = info.files["note" + noteCount + "body" + noteKey + "k"], layer = info.layers["notebody"] });
                images.Add(new Image() { name = "note" + noteCount + "tail", path = info.files["note" + noteCount + "tail" + noteKey + "k"], layer = info.layers["notetail"] });
                images.Add(new Image() { name = "note" + noteCount + "head", path = info.files["note" + noteCount + "head" + noteKey + "k"], layer = info.layers["notehead"] });
                images.Add(new Image() { name = "note" + noteCount, path = info.files["note" + noteCount + noteKey + "k"], layer = info.layers["note"] });
            }


            return images;
        }

        public static Dictionary<string, Dictionary<string, NoteComponent>> GetNotes(int keymode, bool sidetracks)
        {
            Dictionary<string, Dictionary<string, NoteComponent>> notes = new Dictionary<string, Dictionary<string, NoteComponent>>();

            string dir = info.files["positions" + keymode + "k" + (sidetracks ? "2st" : "")];
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
                            layer = info.layers["measure"],
                            image = "measure"
                        }
                    }
                };


            List<Dictionary<string, string>> itemsValues = new List<Dictionary<string, string>>();

            if(sidetracks)
            {
                string name = keymode == 10 ? "scratch1" : "key1";
                itemsValues.Add(
                        new Dictionary<string, string>()
                        {
                            { "name", name },
                            { "layer", "st" },
                            { "image", "st" },
                            { "lnBodyLayer", "stbody" },
                            { "lnBodyImage", "stbody" },
                            { "lnTailLayer", "sttail" },
                            { "lnTailImage", "sttail" },
                            { "lnHeadLayer", "sthead" },
                            { "lnHeadImage", "sthead" },
                        }
                    );
            }

            Dictionary<string, Dictionary<string, List<double>>> itemPositions;
            foreach (Dictionary<string, string> values in itemsValues)
            {
                itemPositions = positions[values["name"]]["ShortNote"];
                notes[values["name"] + ":" + eNoteType.ShortNote] =
                    new Dictionary<string, NoteComponent>() {
                        {
                            eNoteComponent.Head.ToString(),
                            new NoteComponent() {
                                cs = 1,
                                gc = new Gc {
                                    x = itemPositions["Head"]["x"], y = itemPositions["Head"]["y"],
                                    w = itemPositions["Head"]["w"], h = itemPositions["Head"]["h"],
                                    ox = itemPositions["Head"]["ox"], oy = itemPositions["Head"]["oy"]
                                },
                                layer = info.layers[values["layer"]],
                                image = values["image"]
                            }
                        }
                    };

                itemPositions = positions[values["name"]]["SoundNote"];
                notes[values["name"] + ":" + eNoteType.SoundNote] =
                    new Dictionary<string, NoteComponent>() {
                        {
                            eNoteComponent.Head.ToString(),
                            new NoteComponent() {
                                cs = 1,
                                gc = new Gc {
                                    x = itemPositions["Head"]["x"], y = itemPositions["Head"]["y"],
                                    w = itemPositions["Head"]["w"], h = itemPositions["Head"]["h"],
                                    ox = itemPositions["Head"]["ox"], oy = itemPositions["Head"]["oy"]
                                },
                                layer = info.layers[values["layer"]],
                                image = values["image"]
                            }
                        }
                    };

                itemPositions = positions[values["name"]]["LongNote"];
                notes[values["name"] + ":" + eNoteType.LongNote] =
                    new Dictionary<string, NoteComponent>() {
                        {
                            eNoteComponent.Body.ToString(),
                            new NoteComponent() {
                                cs = 1,
                                gc = new Gc {
                                    x = itemPositions["Body"]["x"], y = itemPositions["Body"]["y"],
                                    w = itemPositions["Body"]["w"], h = itemPositions["Body"]["h"],
                                    ox = itemPositions["Body"]["ox"], oy = itemPositions["Body"]["oy"]
                                },
                                layer = info.layers[values["lnBodyLayer"]],
                                image = values["lnBodyImage"]
                            }
                        },
                        {
                            eNoteComponent.Tail.ToString(),
                            new NoteComponent() {
                                cs = 1,
                                gc = new Gc {
                                    x = itemPositions["Tail"]["x"], y = itemPositions["Tail"]["y"],
                                    w = itemPositions["Tail"]["w"], h = itemPositions["Tail"]["h"],
                                    ox = itemPositions["Tail"]["ox"], oy = itemPositions["Tail"]["oy"]
                                },
                                layer = info.layers[values["lnTailLayer"]],
                                image = values["lnTailImage"]
                            }
                        },
                        {
                            eNoteComponent.Head.ToString(),
                            new NoteComponent() {
                                cs = 1,
                                gc = new Gc {
                                    x = itemPositions["Head"]["x"], y = itemPositions["Head"]["y"],
                                    w = itemPositions["Head"]["w"], h = itemPositions["Head"]["h"],
                                    ox = itemPositions["Head"]["ox"], oy = itemPositions["Head"]["oy"]
                                },
                                layer = info.layers[values["lnHeadLayer"]],
                                image = values["lnHeadImage"]
                            }
                        }
                    };
            }



            return notes;
        }
    }
}
