﻿using elements.Enums;
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

            if (sidetracks)
            {
                json = File.ReadAllText(info.files["positionsplayfield2st"]);
                var positionsST = JsonConvert.DeserializeObject<PlayfieldSTPositions>(json);
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
                    cs = info.csMiddle,
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

            



            //temp
            for(int i=1; i<=4; i++)
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
                    inputIndex = positionsKeymode["key" + i].inputIndex,
                    pressed = info.files["keypressed4k"],
                    released = info.files["key4k"],
                });
            }





            return playfield;
        }
    }
}
