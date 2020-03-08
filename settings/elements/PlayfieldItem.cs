using elements.Enums;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using elements.PlayfieldItems;
using logger;

namespace elements
{
    public class PlayfieldItem
    {
        [JsonProperty("class")]
        [JsonConverter(typeof(StringEnumConverter))]
        public eClass classa { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double w { get; set; }
        public double h { get; set; }
        public int layer { get; set; }
        public object[] cs { get; set; }

        public PlayfieldItem()
        {
            classa = eClass.ProgressBar;
            x = 0;
            y = 0;
            w = 0;
            h = 0;
            layer = 0;
        }

        public static List<PlayfieldItem> GetPlayfield(string keymode, bool sidetracks, Dictionary<string, bool> componentsSettings)
        {
            Logger.Add(eMessageType.process, "Making playfield");
            List<PlayfieldItem> playfield = new List<PlayfieldItem>();

            Logger.Add(eMessageType.process, "Getting playfield position jsons");
            string json = File.ReadAllText(Info.files["positionsplayfield"]);
            var positions = JsonConvert.DeserializeObject<PlayfieldPositions>(json);

            var positionsST = new PlayfieldSTPositions();
            if (sidetracks)
            {
                json = File.ReadAllText(Info.files["positionsplayfield2st"]);
                positionsST = JsonConvert.DeserializeObject<PlayfieldSTPositions>(json);
            }

            json = File.ReadAllText(Info.files["positionsplayfield" + keymode]);
            var positionsKeymode = JsonConvert.DeserializeObject<PlayfieldKeymodePositions>(json);


            if (componentsSettings["novidbg"])
            {
                playfield.Add(new StaticObject() { classa = eClass.StaticObject,
                    x = positions.novidbg.x, y = positions.novidbg.y,
                    w = positions.novidbg.w, h = positions.novidbg.h,
                    layer = Info.layers["novidbg"], cs = new object[] { 0.5, 0, 0, 0, eBinding.max.ToString() },
                    image = Info.files["novidbg"] });
            }

            playfield.Add(new StaticObject() { classa = eClass.StaticObject,
                x = positions.bg.x, y = positions.bg.y,
                w = positions.bg.w, h = positions.bg.h,
                layer = Info.layers["bg"], cs = Info.cs,
                image = Info.files["bg"] });

            if (componentsSettings["combobg"])
            {
                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.combobg.x,
                    y = positions.combobg.y,
                    w = positions.combobg.w,
                    h = positions.combobg.h,
                    layer = Info.layers["combobg"],
                    cs = Info.cs,
                    image = Info.files["combobg"]
                });
            }

            playfield.Add(new StaticObject()
            {
                classa = eClass.StaticObject,
                x = positions.judgeline.x,
                y = positions.judgeline.y,
                w = positions.judgeline.w,
                h = positions.judgeline.h,
                layer = Info.layers["judgeline"],
                cs = Info.cs,
                image = Info.files["judgeline"]
            });

            playfield.Add(new StaticObject()
            {
                classa = eClass.StaticObject,
                x = positions.playfield.x,
                y = positions.playfield.y,
                w = positions.playfield.w,
                h = positions.playfield.h,
                layer = Info.layers["playfield"],
                cs = Info.cs,
                image = Info.files["playfield"]
            });

            if (componentsSettings["combo"])
            {
                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.combo.x,
                    y = positions.combo.y,
                    w = positions.combo.w,
                    h = positions.combo.h,
                    layer = Info.layers["combo"],
                    cs = Info.cs,
                    image = Info.files["combo"]
                });

                playfield.Add(new ScoreDisplay()
                {
                    classa = eClass.ScoreDisplay,
                    x = positions.combogame.x,
                    y = positions.combogame.y,
                    w = positions.combogame.w,
                    h = positions.combogame.h,
                    layer = Info.layers["combo"],
                    cs = Info.cs,
                    color = positions.combogame.color,
                    format = "%d",
                    field = eField.combo,
                    align = new Dictionary<string, string>() { { "x", "center" }, { "y", "top" } },
                    font = Info.soundspherePath + Info.files["Haettenschweiler"],
                    size = positions.combogame.size
                });
            }

            if (componentsSettings["progressbar"])
            { 
                playfield.Add(new ProgressBar()
                {
                    classa = eClass.ProgressBar,
                    x = positions.progressbarleft.x,
                    y = positions.progressbarleft.y,
                    w = positions.progressbarleft.w,
                    h = positions.progressbarleft.h,
                    layer = Info.layers["progressbar"],
                    cs = Info.cs,
                    color = positions.progressbarleft.color,
                    direction = "left-right",
                    mode = "+"
                });

                playfield.Add(new ProgressBar()
                {
                    classa = eClass.ProgressBar,
                    x = positions.progressbarright.x,
                    y = positions.progressbarright.y,
                    w = positions.progressbarright.w,
                    h = positions.progressbarright.h,
                    layer = Info.layers["progressbar"],
                    cs = Info.cs,
                    color = positions.progressbarright.color,
                    direction = "right-left",
                    mode = "+"
                });

                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.progressbarbg.x,
                    y = positions.progressbarbg.y,
                    w = positions.progressbarbg.w,
                    h = positions.progressbarbg.h,
                    layer = Info.layers["progressbarbg"],
                    cs = Info.cs,
                    image = Info.files["progressbarbg"]
                });
            }

            if (componentsSettings["accuracy"])
            {
                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.rate.x,
                    y = positions.rate.y,
                    w = positions.rate.w,
                    h = positions.rate.h,
                    layer = Info.layers["accuracy"],
                    cs = Info.cs,
                    image = Info.files["rate"]
                });

                playfield.Add(new ScoreDisplay()
                {
                    classa = eClass.ScoreDisplay,
                    x = positions.accuracy.x,
                    y = positions.accuracy.y,
                    w = positions.accuracy.w,
                    h = positions.accuracy.h,
                    layer = Info.layers["accuracy"],
                    cs = Info.cs,
                    color = positions.accuracy.color,
                    format = "%0.2f",
                    field = eField.accuracy,
                    align = new Dictionary<string, string>() { { "x", "left" }, { "y", "top" } },
                    font = Info.soundspherePath + Info.files["Lato-Black"],
                    size = positions.accuracy.size
                });
            }

            if (componentsSettings["timegate"])
            {
                playfield.Add(new ScoreDisplay()
                {
                    classa = eClass.ScoreDisplay,
                    x = positions.timegate.x,
                    y = positions.timegate.y,
                    w = positions.timegate.w,
                    h = positions.timegate.h,
                    layer = Info.layers["timegate"],
                    cs = Info.cs,
                    color = positions.timegate.color,
                    format = "%s",
                    field = eField.timegate,
                    align = new Dictionary<string, string>() { { "x", "center" }, { "y", "top" } },
                    font = Info.soundspherePath + Info.files["Bulo Black"],
                    size = positions.timegate.size
                });
            }

            playfield.Add(new ScoreDisplay()
            {
                classa = eClass.ScoreDisplay,
                x = positions.combofield.x,
                y = positions.combofield.y,
                w = positions.combofield.w,
                h = positions.combofield.h,
                layer = Info.layers["combo"],
                cs = Info.cs,
                color = positions.combofield.color,
                format = "%d",
                field = eField.combo,
                align = new Dictionary<string, string>() { { "x", "right" }, { "y", "center" } },
                font = Info.soundspherePath + Info.files["Lato-HeavyItalic"],
                size = positions.combofield.size
            });

            playfield.Add(new ScoreDisplay()
            {
                classa = eClass.ScoreDisplay,
                x = positions.scorefield.x,
                y = positions.scorefield.y,
                w = positions.scorefield.w,
                h = positions.scorefield.h,
                layer = Info.layers["score"],
                cs = Info.cs,
                color = positions.scorefield.color,
                format = "%07d",
                field = eField.score,
                align = new Dictionary<string, string>() { { "x", "right" }, { "y", "center" } },
                font = Info.soundspherePath + Info.files["Lato-Regular"],
                size = positions.scorefield.size
            });

            var keys = keymode switch
            {
                "4k" => 4,
                "5k" => 5,
                _ => 6,
            };
            for (int i=1; i<=keys; i++)
            {
                playfield.Add(new InputImage()
                {
                    classa = eClass.InputImage,
                    x = positionsKeymode["key" + i].x,
                    y = positionsKeymode["key" + i].y,
                    w = positionsKeymode["key" + i].w,
                    h = positionsKeymode["key" + i].h,
                    layer = Info.layers["key"],
                    cs = Info.cs,
                    inputType = eInputType.key,
                    inputIndex = positionsKeymode["key" + i].inputIndex + (sidetracks ? (keymode.Contains("10k") ? 0 : 1) : 0),
                    pressed = componentsSettings["keypressed"] ? Info.files["keypressed" + keys + "k"] : Info.files["key" + keys + "k"],
                    released = Info.files["key" + keys + "k"],
                });

                if (componentsSettings["beam"]) { 
                    playfield.Add(new InputImage()
                    {
                        classa = eClass.InputImage,
                        x = positionsKeymode["beam" + i].x,
                        y = positionsKeymode["beam" + i].y,
                        w = positionsKeymode["beam" + i].w,
                        h = positionsKeymode["beam" + i].h,
                        layer = Info.layers["beam"],
                        cs = Info.cs,
                        inputType = eInputType.key,
                        inputIndex = positionsKeymode["beam" + i].inputIndex + (sidetracks ? (keymode.Contains("10k") ? 0 : 1) : 0),
                        pressed = Info.files["beam" + keys + "k"],
                        released = Info.files["blank"],
                    });
                }

                if (componentsSettings["particles"])
                {
                    playfield.Add(new InputImage()
                    {
                        classa = eClass.InputImage,
                        x = positionsKeymode["particle" + i].x,
                        y = positionsKeymode["particle" + i].y,
                        w = positionsKeymode["particle" + i].w,
                        h = positionsKeymode["particle" + i].h,
                        layer = Info.layers["particle"],
                        cs = Info.cs,
                        inputType = eInputType.key,
                        inputIndex = positionsKeymode["particle" + i].inputIndex + (sidetracks ? (keymode.Contains("10k") ? 0 : 1) : 0),
                        pressed = Info.files["particle"],
                        released = Info.files["blank"],
                    });
                }
            }

            if(keymode == "8k")
            {
                for(int i=1; i<=2; i++)
                {
                    string side = i == 1 ? "left" : "right";

                    
                    playfield.Add(new InputImage()
                    {
                        classa = eClass.InputImage,
                        x = positionsKeymode["fxkey" + i].x,
                        y = positionsKeymode["fxkey" + i].y,
                        w = positionsKeymode["fxkey" + i].w,
                        h = positionsKeymode["fxkey" + i].h,
                        layer = Info.layers["fxkey1"],
                        cs = Info.cs,
                        inputType = eInputType.key,
                        inputIndex = positionsKeymode["fxkey" + i].inputIndex + (sidetracks ? 1 : 0),
                        pressed = componentsSettings["keypressed"] ? Info.files["fx1key" + side + "pressed"] : Info.files["fx1key" + side],
                        released = Info.files["fx1key" + side],
                    });

                    if (componentsSettings["beam"])
                    {
                        playfield.Add(new InputImage()
                        {
                            classa = eClass.InputImage,
                            x = positionsKeymode["fxbeam" + i].x,
                            y = positionsKeymode["fxbeam" + i].y,
                            w = positionsKeymode["fxbeam" + i].w,
                            h = positionsKeymode["fxbeam" + i].h,
                            layer = Info.layers["fxbeam"],
                            cs = Info.cs,
                            inputType = eInputType.key,
                            inputIndex = positionsKeymode["fxbeam" + i].inputIndex + (sidetracks ? 1 : 0),
                            pressed = Info.files["fxbeam"],
                            released = Info.files["blank"],
                        });
                    }

                    if (componentsSettings["particles"])
                    {
                        playfield.Add(new InputImage()
                        {
                            classa = eClass.InputImage,
                            x = positionsKeymode["fxparticle" + i].x,
                            y = positionsKeymode["fxparticle" + i].y,
                            w = positionsKeymode["fxparticle" + i].w,
                            h = positionsKeymode["fxparticle" + i].h,
                            layer = Info.layers["fxparticle"],
                            cs = Info.cs,
                            inputType = eInputType.key,
                            inputIndex = positionsKeymode["fxparticle" + i].inputIndex + (sidetracks ? 1 : 0),
                            pressed = Info.files["fxparticle"],
                            released = Info.files["blank"],
                        });
                    }
                }
            }
            else if(keymode.Contains("10k"))
            {
                for(int i=1; i<=2; i++)
                {
                    for (int j = 1; j <= 2; j++)
                    {
                        string side = j == 1 ? "left" : "right";

                        int keynumber;
                        if(i == 2 && j == 1)
                        {
                            keynumber = 1;
                        }
                        else if(i == 1 && j == 1)
                        {
                            keynumber = 2;
                        }
                        else if(i == 1 && j == 2)
                        {
                            keynumber = 3;
                        }
                        else
                        {
                            keynumber = 4;
                        }

                        playfield.Add(new InputImage()
                        {
                            classa = eClass.InputImage,
                            x = positionsKeymode["fxkey" + keynumber].x,
                            y = positionsKeymode["fxkey" + keynumber].y,
                            w = positionsKeymode["fxkey" + keynumber].w,
                            h = positionsKeymode["fxkey" + keynumber].h,
                            layer = Info.layers["fxkey" + i],
                            cs = Info.cs,
                            inputType = eInputType.key,
                            inputIndex = positionsKeymode["fxkey" + keynumber].inputIndex,
                            pressed = componentsSettings["keypressed"] ? Info.files["fx1key" + side + "pressed"] : (i == 1 ? Info.files["fx1key" + side] : Info.files["blank"]),
                            released = i == 1 ? Info.files["fx1key" + side] : Info.files["blank"],
                        });

                        if (componentsSettings["beam"])
                        {
                            playfield.Add(new InputImage()
                            {
                                classa = eClass.InputImage,
                                x = positionsKeymode["fxbeam" + keynumber].x,
                                y = positionsKeymode["fxbeam" + keynumber].y,
                                w = positionsKeymode["fxbeam" + keynumber].w,
                                h = positionsKeymode["fxbeam" + keynumber].h,
                                layer = Info.layers["fxbeam"],
                                cs = Info.cs,
                                inputType = eInputType.key,
                                inputIndex = positionsKeymode["fxbeam" + keynumber].inputIndex,
                                pressed = Info.files["fxbeam"],
                                released = Info.files["blank"],
                            });
                        }

                        if (componentsSettings["particles"])
                        {
                            playfield.Add(new InputImage()
                            {
                                classa = eClass.InputImage,
                                x = positionsKeymode["fxparticle" + keynumber].x,
                                y = positionsKeymode["fxparticle" + keynumber].y,
                                w = positionsKeymode["fxparticle" + keynumber].w,
                                h = positionsKeymode["fxparticle" + keynumber].h,
                                layer = Info.layers["fxparticle"],
                                cs = Info.cs,
                                inputType = eInputType.key,
                                inputIndex = positionsKeymode["fxparticle" + keynumber].inputIndex,
                                pressed = Info.files["fxparticle"],
                                released = Info.files["blank"],
                            });
                        }
                    }
                }
            }

            
            if (sidetracks && componentsSettings["particles"])
            {
                int keyAmount;
                if(keymode == "4k")
                {
                    keyAmount = 4;
                }
                else if(keymode == "5k")
                {
                    keyAmount = 5;
                }
                else if(keymode == "6k")
                {
                    keyAmount = 6;
                }
                else if (keymode == "8k")
                {
                    keyAmount = 8;
                }
                else
                {
                    keyAmount = 10;
                }

                playfield.Add(new InputImage()
                {
                    classa = eClass.InputImage,
                    x = positionsST[1].x,
                    y = positionsST[1].y,
                    w = positionsST[1].w,
                    h = positionsST[1].h,
                    layer = Info.layers["stparticle"],
                    cs = Info.cs,
                    inputType = keymode.Contains("10k") ? eInputType.scratch : eInputType.key,
                    inputIndex = 1,
                    pressed = Info.files["stparticle"],
                    released = Info.files["blank"],
                });

                playfield.Add(new InputImage()
                {
                    classa = eClass.InputImage,
                    x = positionsST[2].x,
                    y = positionsST[2].y,
                    w = positionsST[2].w,
                    h = positionsST[2].h,
                    layer = Info.layers["stparticle"],
                    cs = Info.cs,
                    inputType = keymode.Contains("10k") ? eInputType.scratch : eInputType.key,
                    inputIndex = keymode.Contains("10k") ? 2 : keyAmount + 2,
                    pressed = Info.files["stparticle"],
                    released = Info.files["blank"],
                });
            }

            Logger.Add(eMessageType.completion, "Making playfield complete");
            return playfield;
        }
    }
}
