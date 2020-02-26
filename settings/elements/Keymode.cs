using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using logger;

namespace elements
{
    public class Keymode
    {
        [JsonIgnore]
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

        public static Dictionary<string, Dictionary<string, NoteComponent>> GetNotes(int keymode, bool sidetracks)
        {
            Logger.Add(eMessageType.process, "Getting notes for keymode");

            Dictionary<string, Dictionary<string, NoteComponent>> notes = new Dictionary<string, Dictionary<string, NoteComponent>>();

            Logger.Add(eMessageType.process, "Getting position json path from Info");
            string dir = info.files["positions" + keymode + "k" + (sidetracks ? "2st" : "")];
            Logger.Add(eMessageType.value, "Position json path: " + dir);
            Logger.Add(eMessageType.process, "Reading position json");
            string json = File.ReadAllText(dir);
            Logger.Add(eMessageType.process, "Deserializing position json to object");
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
                itemsValues.Add(new Dictionary<string, string>() {{ "name", name },
                        { "layer", "st" }, { "lnBodyLayer", "stbody" }, { "lnTailLayer", "sttail" }, { "lnHeadLayer", "sthead" },
                        { "image", "st" }, { "lnBodyImage", "stbody" }, { "lnTailImage", "sttail" }, { "lnHeadImage", "sthead" }});
            }

            int keyItem = sidetracks && keymode != 10 ? 2 : 1;
            switch (keymode)
            {
                case 4:
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note2" }, { "lnBodyImage", "note2body" }, { "lnTailImage", "note2tail" }, { "lnHeadImage", "note2head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note2" }, { "lnBodyImage", "note2body" }, { "lnTailImage", "note2tail" }, { "lnHeadImage", "note2head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    break;

                case 5:
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note2" }, { "lnBodyImage", "note2body" }, { "lnTailImage", "note2tail" }, { "lnHeadImage", "note2head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note2" }, { "lnBodyImage", "note2body" }, { "lnTailImage", "note2tail" }, { "lnHeadImage", "note2head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    break;

                case 6:
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note2" }, { "lnBodyImage", "note2body" }, { "lnTailImage", "note2tail" }, { "lnHeadImage", "note2head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note2" }, { "lnBodyImage", "note2body" }, { "lnTailImage", "note2tail" }, { "lnHeadImage", "note2head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    break;

                case 8:
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note2" }, { "lnBodyImage", "note2body" }, { "lnTailImage", "note2tail" }, { "lnHeadImage", "note2head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "fx1" }, { "lnBodyLayer", "fx1body" }, { "lnTailLayer", "fx1tail" }, { "lnHeadLayer", "fx1head" },
                        { "image", "fxleft" }, { "lnBodyImage", "fxleftbody" }, { "lnTailImage", "fxlefttail" }, { "lnHeadImage", "fxlefthead" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "fx1" }, { "lnBodyLayer", "fx1body" }, { "lnTailLayer", "fx1tail" }, { "lnHeadLayer", "fx1head" },
                        { "image", "fxright" }, { "lnBodyImage", "fxrightbody" }, { "lnTailImage", "fxrighttail" }, { "lnHeadImage", "fxrighthead" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note2" }, { "lnBodyImage", "note2body" }, { "lnTailImage", "note2tail" }, { "lnHeadImage", "note2head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    break;

                case 10:
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "fx2" }, { "lnBodyLayer", "fx2body" }, { "lnTailLayer", "fx2tail" }, { "lnHeadLayer", "fx2head" },
                        { "image", "fx2left" }, { "lnBodyImage", "fx2leftbody" }, { "lnTailImage", "fx2lefttail" }, { "lnHeadImage", "fx2lefthead" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note2" }, { "lnBodyImage", "note2body" }, { "lnTailImage", "note2tail" }, { "lnHeadImage", "note2head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "fx1" }, { "lnBodyLayer", "fx1body" }, { "lnTailLayer", "fx1tail" }, { "lnHeadLayer", "fx1head" },
                        { "image", "fx1left" }, { "lnBodyImage", "fx1leftbody" }, { "lnTailImage", "fx1lefttail" }, { "lnHeadImage", "fx1lefthead" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "fx1" }, { "lnBodyLayer", "fx1body" }, { "lnTailLayer", "fx1tail" }, { "lnHeadLayer", "fx1head" },
                        { "image", "fx1right" }, { "lnBodyImage", "fx1rightbody" }, { "lnTailImage", "fx1righttail" }, { "lnHeadImage", "fx1righthead" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note2" }, { "lnBodyImage", "note2body" }, { "lnTailImage", "note2tail" }, { "lnHeadImage", "note2head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "note" }, { "lnBodyLayer", "notebody" }, { "lnTailLayer", "notetail" }, { "lnHeadLayer", "notehead" },
                        { "image", "note1" }, { "lnBodyImage", "note1body" }, { "lnTailImage", "note1tail" }, { "lnHeadImage", "note1head" }});
                    itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "fx2" }, { "lnBodyLayer", "fx2body" }, { "lnTailLayer", "fx2tail" }, { "lnHeadLayer", "fx2head" },
                        { "image", "fx2right" }, { "lnBodyImage", "fx2rightbody" }, { "lnTailImage", "fx2righttail" }, { "lnHeadImage", "fx2righthead" }});
                    break;
            }


            if (sidetracks)
            {
                string name = keymode == 10 ? "scratch2" : "key" + keyItem;
                itemsValues.Add(new Dictionary<string, string>() {{ "name", name },
                        { "layer", "st" }, { "lnBodyLayer", "stbody" }, { "lnTailLayer", "sttail" }, { "lnHeadLayer", "sthead" },
                        { "image", "st" }, { "lnBodyImage", "stbody" }, { "lnTailImage", "sttail" }, { "lnHeadImage", "sthead" }});
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

                //itemPositions = positions[values["name"]]["SoundNote"];
                //notes[values["name"] + ":" + eNoteType.SoundNote] =
                //    new Dictionary<string, NoteComponent>() {
                //        {
                //            eNoteComponent.Head.ToString(),
                //            new NoteComponent() {
                //                cs = 1,
                //                gc = new Gc {
                //                    x = itemPositions["Head"]["x"], y = itemPositions["Head"]["y"],
                //                    w = itemPositions["Head"]["w"], h = itemPositions["Head"]["h"],
                //                    ox = itemPositions["Head"]["ox"], oy = itemPositions["Head"]["oy"]
                //                },
                //                layer = info.layers[values["layer"]],
                //                image = values["image"]
                //            }
                //        }
                //    };

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


            Logger.Add(eMessageType.completion, "Getting notes for keymode complete");
            return notes;
        }
    }
}
