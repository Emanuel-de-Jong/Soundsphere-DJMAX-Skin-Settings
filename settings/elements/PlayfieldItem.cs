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

            if (sidetracks)
            {
                json = File.ReadAllText(info.files["positionsplayfield2st"]);
                var positionsST = JsonConvert.DeserializeObject<PlayfieldSTPositions>(json);
            }

            json = File.ReadAllText(info.files["positionsplayfield" + keymode + "k"]);
            var positionsKeymode = JsonConvert.DeserializeObject<PlayfieldKeymodePositions>(json);



            if (!userSettings["vidbg"])
            {
                playfield.Add(new StaticObject() { classa = eClass.StaticObject,
                    x = positions.novidbg["x"], y = positions.novidbg["y"],
                    w = positions.novidbg["w"], h = positions.novidbg["h"],
                    layer = info.layers["novidbg"], cs = info.cs,
                    image = info.files["novidbg"] });
            }

            playfield.Add(new StaticObject() { classa = eClass.StaticObject,
                x = positions.bg["x"], y = positions.bg["y"],
                w = positions.bg["w"], h = positions.bg["h"],
                layer = info.layers["bg"], cs = info.cs,
                image = info.files["bg"] });

            if (userSettings["combobg"])
            {
                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.combobg["x"],
                    y = positions.combobg["y"],
                    w = positions.combobg["w"],
                    h = positions.combobg["h"],
                    layer = info.layers["combobg"],
                    cs = info.cs,
                    image = info.files["combobg"]
                });
            }

            playfield.Add(new StaticObject()
            {
                classa = eClass.StaticObject,
                x = positions.judgeline["x"],
                y = positions.judgeline["y"],
                w = positions.judgeline["w"],
                h = positions.judgeline["h"],
                layer = info.layers["judgeline"],
                cs = info.cs,
                image = info.files["judgeline"]
            });

            playfield.Add(new StaticObject()
            {
                classa = eClass.StaticObject,
                x = positions.playfield["x"],
                y = positions.playfield["y"],
                w = positions.playfield["w"],
                h = positions.playfield["h"],
                layer = info.layers["playfield"],
                cs = info.cs,
                image = info.files["playfield"]
            });

            if (userSettings["combo"])
            {
                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.combo["x"],
                    y = positions.combo["y"],
                    w = positions.combo["w"],
                    h = positions.combo["h"],
                    layer = info.layers["combo"],
                    cs = info.cs,
                    image = info.files["combo"]
                });

                playfield.Add(new ScoreDisplay()
                {
                    classa = eClass.ScoreDisplay,
                    x = Convert.ToDouble(positions.combogame["x"]),
                    y = Convert.ToDouble(positions.combogame["y"]),
                    w = Convert.ToDouble(positions.combogame["w"]),
                    h = Convert.ToDouble(positions.combogame["h"]),
                    layer = info.layers["combo"],
                    cs = info.cs,
                    color = (int[])positions.combogame["color"],
                    format = "%d",
                    field = eField.combo,
                    align = new Dictionary<string, string>() { { "x", "right" }, { "y", "center" } },
                    font = info.files["Haettenschweiler"],
                    size = (int)positions.combogame["size"]
                });
            }

            if (userSettings["progressbar"])
            { 
                playfield.Add(new ProgressBar()
                {
                    classa = eClass.ProgressBar,
                    x = Convert.ToDouble(positions.progressbar["x"]),
                    y = Convert.ToDouble(positions.progressbar["y"]),
                    w = Convert.ToDouble(positions.progressbar["w"]),
                    h = Convert.ToDouble(positions.progressbar["h"]),
                    layer = info.layers["progressbar"],
                    cs = info.cs,
                    color = (int[])positions.progressbar["color"],
                    direction = "left-right",
                    mode = "+"
                });

                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.progressbarbg["x"],
                    y = positions.progressbarbg["y"],
                    w = positions.progressbarbg["w"],
                    h = positions.playfield["h"],
                    layer = info.layers["progressbarbg"],
                    cs = info.cs,
                    image = info.files["progressbarbg"]
                });
            }

            playfield.Add(new ProgressBar()
            {
                classa = eClass.ProgressBar,
                x = Convert.ToDouble(positions.progressbar["x"]),
                y = Convert.ToDouble(positions.progressbar["y"]),
                w = Convert.ToDouble(positions.progressbar["w"]),
                h = Convert.ToDouble(positions.progressbar["h"]),
                layer = info.layers["progressbar"],
                cs = info.cs,
                color = (int[])positions.progressbar["color"],
                direction = "right-left",
                mode = "+"
            });

            if (userSettings["accucary"])
            {
                playfield.Add(new StaticObject()
                {
                    classa = eClass.StaticObject,
                    x = positions.rate["x"],
                    y = positions.rate["y"],
                    w = positions.rate["w"],
                    h = positions.rate["h"],
                    layer = info.layers["rate"],
                    cs = info.cs,
                    image = info.files["rate"]
                });

                playfield.Add(new ScoreDisplay()
                {
                    classa = eClass.ScoreDisplay,
                    x = Convert.ToDouble(positions.accuracy["x"]),
                    y = Convert.ToDouble(positions.accuracy["y"]),
                    w = Convert.ToDouble(positions.accuracy["w"]),
                    h = Convert.ToDouble(positions.accuracy["h"]),
                    layer = info.layers["accuracy"],
                    cs = info.cs,
                    color = (int[])positions.accuracy["color"],
                    format = "%0.2f",
                    field = eField.accuracy,
                    align = new Dictionary<string, string>() { { "x", "left" }, { "y", "top" } },
                    font = info.files["Lato-black"],
                    size = (int)positions.accuracy["size"]
                });
            }

            if (userSettings["timegate"])
            {
                playfield.Add(new ScoreDisplay()
                {
                    classa = eClass.ScoreDisplay,
                    x = Convert.ToDouble(positions.timegate["x"]),
                    y = Convert.ToDouble(positions.timegate["y"]),
                    w = Convert.ToDouble(positions.timegate["w"]),
                    h = Convert.ToDouble(positions.timegate["h"]),
                    layer = info.layers["timegate"],
                    cs = info.cs,
                    color = (int[])positions.timegate["color"],
                    format = "%s",
                    field = eField.timegate,
                    align = new Dictionary<string, string>() { { "x", "center" }, { "y", "top" } },
                    font = info.files["Bulo Black"],
                    size = (int)positions.timegate["size"]
                });
            }

            playfield.Add(new ScoreDisplay()
            {
                classa = eClass.ScoreDisplay,
                x = Convert.ToDouble(positions.combofield["x"]),
                y = Convert.ToDouble(positions.combofield["y"]),
                w = Convert.ToDouble(positions.combofield["w"]),
                h = Convert.ToDouble(positions.combofield["h"]),
                layer = info.layers["combofield"],
                cs = info.cs,
                color = (int[])positions.combofield["color"],
                format = "%d",
                field = eField.combo,
                align = new Dictionary<string, string>() { { "x", "right" }, { "y", "center" } },
                font = info.files["Lato-HeavyItalic"],
                size = (int)positions.combofield["size"]
            });

            playfield.Add(new ScoreDisplay()
            {
                classa = eClass.ScoreDisplay,
                x = Convert.ToDouble(positions.scorefield["x"]),
                y = Convert.ToDouble(positions.scorefield["y"]),
                w = Convert.ToDouble(positions.scorefield["w"]),
                h = Convert.ToDouble(positions.scorefield["h"]),
                layer = info.layers["scorefield"],
                cs = info.cs,
                color = (int[])positions.scorefield["color"],
                format = "%07d",
                field = eField.score,
                align = new Dictionary<string, string>() { { "x", "right" }, { "y", "center" } },
                font = info.files["Lato-Regular"],
                size = (int)positions.scorefield["size"]
            });

            





            return playfield;
        }
    }
}
