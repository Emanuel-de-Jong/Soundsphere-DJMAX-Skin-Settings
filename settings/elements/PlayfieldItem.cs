using elements.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using elements.PlayfieldItems;

namespace elements
{
    public class PlayfieldItem
    {
        [JsonIgnore]
        static Info info = new Info();

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

        public static List<PlayfieldItem> GetPlayfield(int keymode, bool sidetracks, Dictionary<string, bool> userSettings)
        {
            List<PlayfieldItem> playfield = new List<PlayfieldItem>();

            string json = File.ReadAllText(info.files["positionsplayfield"]);
            var positions = JsonConvert.DeserializeObject<PlayfieldPositions>(json);

            var positionsST = new PlayfieldSTPositions();
            if (sidetracks)
            {
                json = File.ReadAllText(info.files["positionsplayfield2st"]);
                positionsST = JsonConvert.DeserializeObject<PlayfieldSTPositions>(json);
            }

            json = File.ReadAllText(info.files["positionsplayfield" + keymode + "k"]);
            var positionsKeymode = JsonConvert.DeserializeObject<PlayfieldKeymodePositions>(json);

            string fontPath = "userdata/skins/" + info.skinName + "/";


            if (!userSettings["vidbg"])
            {
                playfield.Add(new StaticObject() { classa = eClass.StaticObject,
                    x = positions.novidbg.x, y = positions.novidbg.y,
                    w = positions.novidbg.w, h = positions.novidbg.h,
                    layer = info.layers["novidbg"], cs = info.cs,
                    image = info.files["novidbg"] });
            }

            playfield.Add(new StaticObject() { classa = eClass.StaticObject,
                x = positions.bg.x, y = positions.bg.y,
                w = positions.bg.w, h = positions.bg.h,
                layer = info.layers["bg"], cs = info.cs,
                image = info.files["bg"] });

            if (userSettings["combobg"])
            {
                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.combobg.x,
                    y = positions.combobg.y,
                    w = positions.combobg.w,
                    h = positions.combobg.h,
                    layer = info.layers["combobg"],
                    cs = info.cs,
                    image = info.files["combobg"]
                });
            }

            playfield.Add(new StaticObject()
            {
                classa = eClass.StaticObject,
                x = positions.judgeline.x,
                y = positions.judgeline.y,
                w = positions.judgeline.w,
                h = positions.judgeline.h,
                layer = info.layers["judgeline"],
                cs = info.cs,
                image = info.files["judgeline"]
            });

            playfield.Add(new StaticObject()
            {
                classa = eClass.StaticObject,
                x = positions.playfield.x,
                y = positions.playfield.y,
                w = positions.playfield.w,
                h = positions.playfield.h,
                layer = info.layers["playfield"],
                cs = info.cs,
                image = info.files["playfield"]
            });

            if (userSettings["combo"])
            {
                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.combo.x,
                    y = positions.combo.y,
                    w = positions.combo.w,
                    h = positions.combo.h,
                    layer = info.layers["combo"],
                    cs = info.cs,
                    image = info.files["combo"]
                });

                playfield.Add(new ScoreDisplay()
                {
                    classa = eClass.ScoreDisplay,
                    x = positions.combogame.x,
                    y = positions.combogame.y,
                    w = positions.combogame.w,
                    h = positions.combogame.h,
                    layer = info.layers["combo"],
                    cs = info.cs,
                    color = positions.combogame.color,
                    format = "%d",
                    field = eField.combo,
                    align = new Dictionary<string, string>() { { "x", "center" }, { "y", "top" } },
                    font = fontPath + info.files["Haettenschweiler"],
                    size = positions.combogame.size
                });
            }

            if (userSettings["progressbar"])
            { 
                playfield.Add(new ProgressBar()
                {
                    classa = eClass.ProgressBar,
                    x = positions.progressbarleft.x,
                    y = positions.progressbarleft.y,
                    w = positions.progressbarleft.w,
                    h = positions.progressbarleft.h,
                    layer = info.layers["progressbar"],
                    cs = info.csMiddle,
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
                    layer = info.layers["progressbar"],
                    cs = info.csMiddle,
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
                    layer = info.layers["progressbarbg"],
                    cs = info.csMiddle,
                    image = info.files["progressbarbg"]
                });
            }

            if (userSettings["accuracy"])
            {
                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.rate.x,
                    y = positions.rate.y,
                    w = positions.rate.w,
                    h = positions.rate.h,
                    layer = info.layers["accuracy"],
                    cs = info.cs,
                    image = info.files["rate"]
                });

                playfield.Add(new ScoreDisplay()
                {
                    classa = eClass.ScoreDisplay,
                    x = positions.accuracy.x,
                    y = positions.accuracy.y,
                    w = positions.accuracy.w,
                    h = positions.accuracy.h,
                    layer = info.layers["accuracy"],
                    cs = info.csMiddle,
                    color = positions.accuracy.color,
                    format = "%0.2f",
                    field = eField.accuracy,
                    align = new Dictionary<string, string>() { { "x", "left" }, { "y", "top" } },
                    font = fontPath + info.files["Lato-Black"],
                    size = positions.accuracy.size
                });
            }

            if (userSettings["timegate"])
            {
                playfield.Add(new ScoreDisplay()
                {
                    classa = eClass.ScoreDisplay,
                    x = positions.timegate.x,
                    y = positions.timegate.y,
                    w = positions.timegate.w,
                    h = positions.timegate.h,
                    layer = info.layers["timegate"],
                    cs = info.cs,
                    color = positions.timegate.color,
                    format = "%s",
                    field = eField.timegate,
                    align = new Dictionary<string, string>() { { "x", "center" }, { "y", "top" } },
                    font = fontPath + info.files["Bulo Black"],
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
                layer = info.layers["combo"],
                cs = info.csMiddle,
                color = positions.combofield.color,
                format = "%d",
                field = eField.combo,
                align = new Dictionary<string, string>() { { "x", "right" }, { "y", "center" } },
                font = fontPath + info.files["Lato-HeavyItalic"],
                size = positions.combofield.size
            });

            playfield.Add(new ScoreDisplay()
            {
                classa = eClass.ScoreDisplay,
                x = positions.scorefield.x,
                y = positions.scorefield.y,
                w = positions.scorefield.w,
                h = positions.scorefield.h,
                layer = info.layers["score"],
                cs = info.csMiddle,
                color = positions.scorefield.color,
                format = "%07d",
                field = eField.score,
                align = new Dictionary<string, string>() { { "x", "right" }, { "y", "center" } },
                font = fontPath + info.files["Lato-Regular"],
                size = positions.scorefield.size
            });


            int keys = keymode > 6 ? 6 : keymode;
            for (int i=1; i<=keys; i++)
            {
                playfield.Add(new InputImage()
                {
                    classa = eClass.InputImage,
                    x = positionsKeymode["key" + i].x,
                    y = positionsKeymode["key" + i].y,
                    w = positionsKeymode["key" + i].w,
                    h = positionsKeymode["key" + i].h,
                    layer = info.layers["key"],
                    cs = info.csMiddle,
                    inputType = eInputType.key,
                    inputIndex = positionsKeymode["key" + i].inputIndex + (sidetracks ? (keymode == 10 ? 0 : 1) : 0),
                    pressed = userSettings["keypressed"] ? info.files["keypressed" + keys + "k"] : info.files["key" + keys + "k"],
                    released = info.files["key" + keys + "k"],
                });

                if (userSettings["beam"]) { 
                    playfield.Add(new InputImage()
                    {
                        classa = eClass.InputImage,
                        x = positionsKeymode["beam" + i].x,
                        y = positionsKeymode["beam" + i].y,
                        w = positionsKeymode["beam" + i].w,
                        h = positionsKeymode["beam" + i].h,
                        layer = info.layers["beam"],
                        cs = info.csMiddle,
                        inputType = eInputType.key,
                        inputIndex = positionsKeymode["beam" + i].inputIndex + (sidetracks ? (keymode == 10 ? 0 : 1) : 0),
                        pressed = info.files["beam" + keys + "k"],
                        released = info.files["blank"],
                    });
                }

                if (userSettings["particles"])
                {
                    playfield.Add(new InputImage()
                    {
                        classa = eClass.InputImage,
                        x = positionsKeymode["particle" + i].x,
                        y = positionsKeymode["particle" + i].y,
                        w = positionsKeymode["particle" + i].w,
                        h = positionsKeymode["particle" + i].h,
                        layer = info.layers["particle"],
                        cs = info.csMiddle,
                        inputType = eInputType.key,
                        inputIndex = positionsKeymode["particle" + i].inputIndex + (sidetracks ? (keymode == 10 ? 0 : 1) : 0),
                        pressed = info.files["particle"],
                        released = info.files["blank"],
                    });
                }
            }

            if(keymode == 8)
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
                        layer = info.layers["fxkey1"],
                        cs = info.csMiddle,
                        inputType = eInputType.key,
                        inputIndex = positionsKeymode["fxkey" + i].inputIndex + (sidetracks ? 1 : 0),
                        pressed = userSettings["keypressed"] ? info.files["fxkey" + side + "pressed"] : info.files["fxkey" + side],
                        released = info.files["fxkey" + side],
                    });

                    if (userSettings["beam"])
                    {
                        playfield.Add(new InputImage()
                        {
                            classa = eClass.InputImage,
                            x = positionsKeymode["fxbeam" + i].x,
                            y = positionsKeymode["fxbeam" + i].y,
                            w = positionsKeymode["fxbeam" + i].w,
                            h = positionsKeymode["fxbeam" + i].h,
                            layer = info.layers["fxbeam"],
                            cs = info.csMiddle,
                            inputType = eInputType.key,
                            inputIndex = positionsKeymode["fxbeam" + i].inputIndex + (sidetracks ? 1 : 0),
                            pressed = info.files["fxbeam"],
                            released = info.files["blank"],
                        });
                    }

                    if (userSettings["particles"])
                    {
                        playfield.Add(new InputImage()
                        {
                            classa = eClass.InputImage,
                            x = positionsKeymode["fxparticle" + i].x,
                            y = positionsKeymode["fxparticle" + i].y,
                            w = positionsKeymode["fxparticle" + i].w,
                            h = positionsKeymode["fxparticle" + i].h,
                            layer = info.layers["fxparticle"],
                            cs = info.csMiddle,
                            inputType = eInputType.key,
                            inputIndex = positionsKeymode["fxparticle" + i].inputIndex + (sidetracks ? 1 : 0),
                            pressed = info.files["fxparticle"],
                            released = info.files["blank"],
                        });
                    }
                }
            }
            else if(keymode == 10)
            {
                for(int i=1; i<=2; i++)
                {
                    for (int j = 1; j <= 2; j++)
                    {
                        string side = j == 1 ? "left" : "right";

                        int keynumber = 0;
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
                            layer = info.layers["fxkey" + i],
                            cs = info.csMiddle,
                            inputType = eInputType.key,
                            inputIndex = positionsKeymode["fxkey" + keynumber].inputIndex,
                            pressed = userSettings["keypressed"] ? info.files["fxkey" + side + "pressed"] : (i == 1 ? info.files["fxkey" + side] : info.files["blank"]),
                            released = i == 1 ? info.files["fxkey" + side] : info.files["blank"],
                        });

                        if (userSettings["beam"])
                        {
                            playfield.Add(new InputImage()
                            {
                                classa = eClass.InputImage,
                                x = positionsKeymode["fxbeam" + keynumber].x,
                                y = positionsKeymode["fxbeam" + keynumber].y,
                                w = positionsKeymode["fxbeam" + keynumber].w,
                                h = positionsKeymode["fxbeam" + keynumber].h,
                                layer = info.layers["fxbeam"],
                                cs = info.csMiddle,
                                inputType = eInputType.key,
                                inputIndex = positionsKeymode["fxbeam" + keynumber].inputIndex,
                                pressed = info.files["fxbeam"],
                                released = info.files["blank"],
                            });
                        }

                        if (userSettings["particles"])
                        {
                            playfield.Add(new InputImage()
                            {
                                classa = eClass.InputImage,
                                x = positionsKeymode["fxparticle" + keynumber].x,
                                y = positionsKeymode["fxparticle" + keynumber].y,
                                w = positionsKeymode["fxparticle" + keynumber].w,
                                h = positionsKeymode["fxparticle" + keynumber].h,
                                layer = info.layers["fxparticle"],
                                cs = info.csMiddle,
                                inputType = eInputType.key,
                                inputIndex = positionsKeymode["fxparticle" + keynumber].inputIndex,
                                pressed = info.files["fxparticle"],
                                released = info.files["blank"],
                            });
                        }
                    }
                }
            }

            if (sidetracks)
            {
                playfield.Add(new InputImage()
                {
                    classa = eClass.InputImage,
                    x = positionsST[1].x,
                    y = positionsST[1].y,
                    w = positionsST[1].w,
                    h = positionsST[1].h,
                    layer = info.layers["stparticle"],
                    cs = info.csMiddle,
                    inputType = keymode == 10 ? eInputType.scratch : eInputType.key,
                    inputIndex = 1,
                    pressed = info.files["stparticle"],
                    released = info.files["blank"],
                });

                playfield.Add(new InputImage()
                {
                    classa = eClass.InputImage,
                    x = positionsST[2].x,
                    y = positionsST[2].y,
                    w = positionsST[2].w,
                    h = positionsST[2].h,
                    layer = info.layers["stparticle"],
                    cs = info.csMiddle,
                    inputType = keymode == 10 ? eInputType.scratch : eInputType.key,
                    inputIndex = keymode == 10 ? 2 : keymode + 2,
                    pressed = info.files["stparticle"],
                    released = info.files["blank"],
                });
            }


            return playfield;
        }
    }
}
