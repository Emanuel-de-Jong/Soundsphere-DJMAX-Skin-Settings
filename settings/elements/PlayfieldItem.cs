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



            if (userSettings["novidbg"])
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





            return playfield;
        }
    }
}
