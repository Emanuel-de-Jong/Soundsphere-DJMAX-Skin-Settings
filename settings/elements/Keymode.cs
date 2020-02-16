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
                images.Add(new Image() { name = "st", path = info.files["st"], layer = info.layers["stbody"] });
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

        public static Dictionary<string, Dictionary<string, NoteComponent>> GetNotes(int keymode, bool sidetracks, List<Image> images)
        {
            Dictionary<string, Dictionary<string, NoteComponent>> notes = new Dictionary<string, Dictionary<string, NoteComponent>>();

            string dir = "settingsresources/positions/positions" + keymode + "K";
            dir += sidetracks ? "2ST" : "";
            dir += ".json";
            string json = File.ReadAllText(dir);
            var positions = JsonConvert.DeserializeObject<Positions>(json);

            int imgIndex = 0;

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
                            layer = images[imgIndex].layer,
                            image = images[imgIndex].name
                        }
                    }
                };

            List<int> imgIndexes = new List<int>() { 0 };
            switch (keymode)
            {
                case 4:
                    imgIndexes.Add(imgIndex + 1);
                    imgIndexes.Add(imgIndex + 5);
                    imgIndexes.Add(imgIndex + 5);
                    imgIndexes.Add(imgIndex + 1);
                    break;
                case 5:
                    imgIndexes.Add(imgIndex + 1);
                    imgIndexes.Add(imgIndex + 5);
                    imgIndexes.Add(imgIndex + 1);
                    imgIndexes.Add(imgIndex + 5);
                    imgIndexes.Add(imgIndex + 1);
                    break;
                default:
                    imgIndexes.Add(imgIndex + 1);
                    imgIndexes.Add(imgIndex + 5);
                    imgIndexes.Add(imgIndex + 1);
                    imgIndexes.Add(imgIndex + 1);
                    imgIndexes.Add(imgIndex + 5);
                    imgIndexes.Add(imgIndex + 1);
                    break;
            }

            int loops = keymode >= 6 ? 6 : keymode;
            for (int i=1; i<= loops; i++)
            {
                var keyPos = positions[i];

                var longNotePos = keyPos[eNoteType.LongNote.ToString()];
                notes["key" + i + ":" + eNoteType.LongNote] =
                    new Dictionary<string, NoteComponent>() {
                        {
                            eNoteComponent.Body.ToString(),
                            new NoteComponent() {
                                cs = 1,
                                gc = new Gc {
                                    x = longNotePos["Body"]["x"], y = longNotePos["Body"]["y"],
                                    w = longNotePos["Body"]["w"], h = longNotePos["Body"]["h"],
                                    ox = longNotePos["Body"]["ox"], oy = longNotePos["Body"]["oy"]
                                },
                                layer = images[imgIndexes[i]].layer,
                                image = images[imgIndexes[i]].name
                            }
                        },
                        {
                            eNoteComponent.Tail.ToString(),
                            new NoteComponent() {
                                cs = 1,
                                gc = new Gc {
                                    x = longNotePos["Tail"]["x"], y = longNotePos["Tail"]["y"],
                                    w = longNotePos["Tail"]["w"], h = longNotePos["Tail"]["h"],
                                    ox = longNotePos["Tail"]["ox"], oy = longNotePos["Tail"]["oy"]
                                },
                                layer = images[imgIndexes[i]+1].layer,
                                image = images[imgIndexes[i]+1].name
                            }
                        },
                        {
                            eNoteComponent.Head.ToString(),
                            new NoteComponent() {
                                cs = 1,
                                gc = new Gc {
                                    x = longNotePos["Head"]["x"], y = longNotePos["Head"]["y"],
                                    w = longNotePos["Head"]["w"], h = longNotePos["Head"]["h"],
                                    ox = longNotePos["Head"]["ox"], oy = longNotePos["Head"]["oy"]
                                },
                                layer = images[imgIndexes[i]+2].layer,
                                image = images[imgIndexes[i]+2].name
                            }
                        }
                    };

                var shortNotePos = keyPos[eNoteType.ShortNote.ToString()];
                notes["key" + i + ":" + eNoteType.ShortNote] =
                    new Dictionary<string, NoteComponent>() {
                        {
                            eNoteComponent.Head.ToString(),
                            new NoteComponent() {
                                cs = 1,
                                gc = new Gc {
                                    x = shortNotePos["Head"]["x"], y = shortNotePos["Head"]["y"],
                                    w = shortNotePos["Head"]["w"], h = shortNotePos["Head"]["h"],
                                    ox = shortNotePos["Head"]["ox"], oy = shortNotePos["Head"]["oy"]
                                },
                                layer = images[imgIndexes[i]+3].layer,
                                image = images[imgIndexes[i]+3].name
                            }
                        }
                    };

                var soundNotePos = keyPos[eNoteType.SoundNote.ToString()];
                notes["key" + i + ":" + eNoteType.SoundNote] =
                    new Dictionary<string, NoteComponent>() {
                        {
                            eNoteComponent.Head.ToString(),
                            new NoteComponent() {
                                cs = 1,
                                gc = new Gc {
                                    x = soundNotePos["Head"]["x"], y = soundNotePos["Head"]["y"],
                                    w = soundNotePos["Head"]["w"], h = soundNotePos["Head"]["h"],
                                    ox = soundNotePos["Head"]["ox"], oy = soundNotePos["Head"]["oy"]
                                },
                                layer = images[imgIndexes[i]+3].layer,
                                image = images[imgIndexes[i]+3].name
                            }
                        }
                    };
            }



            return notes;
        }
    }
}
