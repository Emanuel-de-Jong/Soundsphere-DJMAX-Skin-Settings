using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using logger;

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

        public static Dictionary<string, Dictionary<string, NoteComponent>> GetNotes(string keymode, bool sidetracks)
        {
            Logger.Add(eMessageType.process, "Getting notes for keymode");

            Dictionary<string, Dictionary<string, NoteComponent>> notes = new Dictionary<string, Dictionary<string, NoteComponent>>();

            Logger.Add(eMessageType.process, "Getting position json path from Info");
            string dir = Info.files["positions" + keymode + (sidetracks ? "2st" : "")];
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
                            layer = Info.layers["measure"],
                            image = "measure"
                        }
                    }
                };


            List<Dictionary<string, string>> itemsValues = new List<Dictionary<string, string>>();



            if (sidetracks)
            {
                string name = keymode.Contains("10k") ? "scratch1" : "key1";
                itemsValues.Add(new Dictionary<string, string>() {{ "name", name },
                        { "layer", "st" }, { "lnBodyLayer", "stbody" }, { "lnTailLayer", "sttail" }, { "lnHeadLayer", "sthead" },
                        { "image", "st" }, { "lnBodyImage", "stbody" }, { "lnTailImage", "sttail" }, { "lnHeadImage", "sthead" }});
            }

            int keyItem = sidetracks && !keymode.Contains("10k") ? 2 : 1;
            if (keymode == "4k")
            {
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
            }

            else if (keymode == "5k")
            {
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
            }

            else if (keymode == "6k")
            {
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
            }

            else if (keymode == "8k")
            {
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
            }

            else if (keymode == "10k")
            {
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
            }
            else if (keymode == "10kfade")
            {
                itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "fx2" }, { "lnBodyLayer", "fx2body" }, { "lnTailLayer", "fx2tail" }, { "lnHeadLayer", "fx2head" },
                        { "image", "fx2left10kfade" }, { "lnBodyImage", "fx2leftbody10kfade" }, { "lnTailImage", "fx2lefttail10kfade" }, { "lnHeadImage", "fx2lefthead10kfade" }});
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
                        { "image", "fx1left10kfade" }, { "lnBodyImage", "fx1leftbody10kfade" }, { "lnTailImage", "fx1lefttail10kfade" }, { "lnHeadImage", "fx1lefthead10kfade" }});
                itemsValues.Add(new Dictionary<string, string>() {{ "name", "key" + keyItem++ },
                        { "layer", "fx1" }, { "lnBodyLayer", "fx1body" }, { "lnTailLayer", "fx1tail" }, { "lnHeadLayer", "fx1head" },
                        { "image", "fx1right10kfade" }, { "lnBodyImage", "fx1rightbody10kfade" }, { "lnTailImage", "fx1righttail10kfade" }, { "lnHeadImage", "fx1righthead10kfade" }});
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
                        { "image", "fx2right10kfade" }, { "lnBodyImage", "fx2rightbody10kfade" }, { "lnTailImage", "fx2righttail10kfade" }, { "lnHeadImage", "fx2righthead10kfade" }});
            }


            if (sidetracks)
            {
                string name = keymode.Contains("10k") ? "scratch2" : "key" + keyItem;
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
                                layer = Info.layers[values["layer"]],
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
                                layer = Info.layers[values["lnBodyLayer"]],
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
                                layer = Info.layers[values["lnTailLayer"]],
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
                                layer = Info.layers[values["lnHeadLayer"]],
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
